$(document).ready(function () {




    $("#btnSubmit").unbind("click").click(function () {
        //todo
        getBackupPlan();
    });



    async function getDataBackUp() {
        //window.location.href = "/BackupPlan/SaveDataAsync";

        try {
            const result = await $.ajax({
                url: "/BackupPlan/SaveDataAsync",
                success: function (data) {
                    debugger;
                    const blob = new Blob([data]);
                    const link = document.createElement("a");
                    link.href = window.URL.createObjectURL(blob);
                    const dt = new Date();
                    const output = dt.getDate() + "-" + dt.getMonth() + "-" + dt.getFullYear();
                    const time = dt.getHours() + "-" + dt.getMinutes() + "-" + dt.getSeconds();
                    link.download = output + "_Backup_BNAMS_" + time + ".tomahawk";
                    link.click();
                }
            });

            return result;
        } catch (error) {
            console.error(error);
        }
        return result;
    };

    async function updateIsBackupStatus() {
        try {
            const result = await $.ajax({
                url: "/BackupPlan/UpdateAllIsBackupStatus",
                type: "POST"
            });

            return result;
        } catch (error) {
            console.error(error);
        }
        return result;
    };

    async function getBackupPlan() {
        debugger;
        try {
            $("#textAreaBackupStatus").val("Preparing Data.Please Wait.... its a critical job");
            await getDataBackUp();
            $("#textAreaBackupStatus").val("Downloading Data....Please wait. 2nd Phase Started");

            const result = await updateIsBackupStatus();
            $("#textAreaBackupStatus").val(result + "  Thanks for your patience.");

        } catch (err) {
            console.log(err);
        }
    }


});

