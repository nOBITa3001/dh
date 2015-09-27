namespace HomeCinema.Services
{
	using Data.Extensions;
	using Data.Infrastructure;
	using Data.Repositories;
	using Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Principal;
	using Utilities;

	public class MembershipService : IMembershipService
	{
		#region Declearations

		private readonly IEntityBaseRepository<User> userRepository;
		private readonly IEntityBaseRepository<Role> roleRepository;
		private readonly IEntityBaseRepository<UserRole> userRoleRepository;
		private readonly IEncryptionService encryptionService;
		private readonly IUnitOfWork unitOfWork;

		#endregion

		#region Constructors

		public MembershipService(IEntityBaseRepository<User> userRepository
									, IEntityBaseRepository<Role> roleRepository
									, IEntityBaseRepository<UserRole> userRoleRepository
									, IEncryptionService encryptionService
									, IUnitOfWork unitOfWork)
		{
			this.userRepository = userRepository;
			this.roleRepository = roleRepository;
			this.userRoleRepository = userRoleRepository;
			this.encryptionService = encryptionService;
			this.unitOfWork = unitOfWork;
		}

		#endregion

		#region Implementations

		public MembershipContext ValidateUser(string username, string password)
		{
			var membershipCtx = new MembershipContext();

			var user = this.userRepository.GetSingleByUsername(username);
			if (user != null && this.IsUserValid(user, password))
			{
				var userRoles = this.GetUserRoles(user);
				membershipCtx.User = user;

				var identity = new GenericIdentity(user.Username);
				membershipCtx.Principal = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
			}

			return membershipCtx;
		}

		public User CreateUser(string username, string email, string password, int[] roles)
		{
			var existingUser = this.userRepository.GetSingleByUsername(username);

			if (existingUser != null)
			{
				throw new Exception("Username is already in use");
			}

			var passwordSalt = this.encryptionService.CreateSalt();

			var user = new User()
			{
				Username = username,
				Salt = passwordSalt,
				Email = email,
				IsLocked = false,
				HashedPassword = this.encryptionService.EncryptPassword(password, passwordSalt),
				DateCreated = DateTime.Now
			};

			this.userRepository.Add(user);

			this.unitOfWork.Commit();

			if (roles != null || roles.Length > 0)
			{
				foreach (var role in roles)
				{
					this.AddUserToRole(user, role);
				}
			}

			this.unitOfWork.Commit();

			return user;
		}

		public User GetUser(int id)
		{
			return this.userRepository.GetSingle(id);
		}

		public List<Role> GetUserRoles(string username)
		{
			var result = new List<Role>();

			var existingUser = this.userRepository.GetSingleByUsername(username);

			if (existingUser != null)
			{
				result = this.GetUserRoles(existingUser);
			}

			return result.Distinct().ToList();
		}

		public List<Role> GetUserRoles(User existingUser)
		{
			var result = new List<Role>();

			if (existingUser != null)
			{
				foreach (var userRole in existingUser.UserRoles)
				{
					result.Add(userRole.Role);
				}
			}

			return result.Distinct().ToList();
		}

		#endregion

		#region Methods

		private void AddUserToRole(User user, int roleId)
		{
			var role = this.roleRepository.GetSingle(roleId);
			if (role == null)
			{
				throw new ApplicationException("Role doesn't exist.");
			}

			var userRole = new UserRole()
			{
				RoleID = role.ID,
				UserID = user.ID
			};

			this.userRoleRepository.Add(userRole);
		}

		private bool IsPasswordValid(User user, string password)
		{
			return string.Equals(this.encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
		}

		private bool IsUserValid(User user, string password)
		{
			var result = false;

			if (this.IsPasswordValid(user, password))
			{
				result = !user.IsLocked;
			}

			return result;
		}

		#endregion
	}
}
