﻿/*site.js*/
(function () {

	//var el = $("#eventName");
	//el.text("Monday's Breakfast");

	//var main = $("#main");
	//main.on("mouseenter", function () {
	//    main.style.backgroundColor = "#888";
	//});

	//main.on("mouseleave", function () {
	//    main.style.backgroundColor = "";
	//});

	//var menuItems = $("ul.menu li a");
	//menuItems.on("click", function () {
	//    var me = $(this);

	//    alert(me.text());
	//});

	var $sidebarAndWrapper = $("#sidebar,#wrapper");
	var $icon = $("#sidebarToggle i.fa");

	$("#sidebarToggle").on("click", function () {
		$sidebarAndWrapper.toggleClass("hide-sidebar");
		if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
			$icon.removeClass("fa-angle-double-left");
			$icon.addClass("fa-angle-double-right");
		} else {
			$icon.addClass("fa-angle-double-left");
			$icon.removeClass("fa-angle-double-right");
		}
	});
})();