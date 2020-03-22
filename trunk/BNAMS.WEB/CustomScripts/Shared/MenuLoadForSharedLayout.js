
$(document).ready(function () {
    var b = [];
    $.ajax({
        type: "GET",
        url: "../RoleWiseMenu/LoadSessionForMenu",
        dataType: "json",
        success: function(data) {
            b = data.data;
            
            var menu = "";
            var submenu = "";
            var subSubMenu = "";
            $.each(b, function (index, item) {
                if (item.ParentId == 0) {

                    var mylicls = "Parent_" + item.Id;
                   
                    menu +=
                        "<li>" +
                        '<a href="javascript:;">' +
                        '<i class="' +
                        item.MenuClass +
                        '">' +
                        "</i>" +
                        '<span class="title">' +
                        item.MenuName +
                        "</span>" +
                        '<span class="arrow ">' +
                        "</span>" +
                        "</a>" +
                        "<ul class='sub-menu' id='" +
                        mylicls +
                        "'>" +
                        "</ul>";
                   
                }
                
            });

           



            $("#menus").append(menu);
            var parentcls = 0;
            $.each(b,
                function (index, item) {
                    parentcls = "Parent_" + item.ParentId;
                    var parentcls1 = "Parent_" + item.Id;
                    //alert(item.MenuName);
                     if (item.ParentId > 0 && item.SubParentId == 0) {
                        
                         submenu = "<li>" +
                             '<a href="javascript:;">' +
                             '<i class="' +
                             item.MenuClass +
                             '">' +
                             "</i>" +
                             '<span class="title">' +
                             item.MenuName +
                             "</span>" +
                             '<span class="arrow ">' +
                             "</span>" +
                             "</a>" +
                             "<ul class='sub-menu' id='" +
                             parentcls1 +
                             "'>" +
                             "</ul>";
                    }
                    else if (item.ParentId > 0) {
                        submenu= " <li>" +
                            "<a href='/" + item.MenuUrl+
                            "'>" +
                            item.MenuName +
                            "</a>" +
                            "</li>";
                    }
                    
                    $("#" + parentcls).append(submenu);
                });


//
            //$("#menus").append(submenu);
            var parentcls2 = 0;
            $.each(b,
                function (index, item) {
                    parentcls2 = "Parent_" + item.SubParentId;
                    
                    if (item.ParentId == 1) {
                        //alert(item.MenuName);   
                        subSubMenu = " <li>" +
                            "<a href='/" + item.MenuUrl +
                            "'>" +
                            item.MenuName +
                            "</a>" +
                            "</li>";
                    }

                    $("#" + parentcls2).append(subSubMenu);
                });
           
            
       
        }
    });

})