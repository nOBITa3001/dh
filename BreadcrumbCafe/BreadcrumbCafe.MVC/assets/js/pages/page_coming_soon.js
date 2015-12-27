var PageComingSoon = function () {

    return {
        
        //Coming Soon
        initPageComingSoon: function () {
			//var newYear = new Date(); 
        	//newYear = new Date(newYear.getFullYear() + 1, 1 - 1, 1); 
			var nextRelease = new Date(2016, 1, 28);
			$('#defaultCountdown').countdown({ until: nextRelease })
        }

    };
}();        