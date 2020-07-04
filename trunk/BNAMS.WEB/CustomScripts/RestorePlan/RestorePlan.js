$(document).ready(function () {




    $("#btnSubmit").unbind("click").click(function () {
        //todo
        restoreBackup();
    });



    async function restoreBackUp() {
        debugger;
        if (window.FormData !== undefined) {
            debugger;
            const fileUpload = $("#getFile").get(0);
            const files = fileUpload.files;

            // Create FormData object  
            const fileData = new FormData();

            // Looping over all files and add it to FormData object  
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }


            try {
                const result = await
                    $.ajax({
                        url: "/RestorePlan/Restore",
                        type: "POST",
                        contentType: false, // Not to set any content header  
                        processData: false, // Not to process data  
                        data: fileData,
                        success: function (result) {
                            $("#textAreaBackupStatus").val(result);
                        },
                        error: function (err) {
                            $("#textAreaBackupStatus").val(err);
                        }
                    });
            
        } catch (error) {
            console.error(error);
        }
        } else {
            $("#textAreaBackupStatus").val("File Not Supported.");
        }

        return result;
    };

   

    async function restoreBackup() {
        debugger;
        try {
            $("#textAreaBackupStatus").val("Preparing Data.Please Wait.... its a critical job");
            await restoreBackUp();

        } catch (err) {
            console.log(err);
        }
    }


});

