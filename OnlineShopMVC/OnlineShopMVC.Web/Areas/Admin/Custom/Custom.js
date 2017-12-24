$(document).ready(function () {
    var id = 0;
    $(".bnt-delete-user").click(function () {
        id = this.getAttribute("data-user-delete")
    })

    $("#modal-success").click(function () {
        $.ajax({
            type: "post",
            url: "/user/delete",
            data: { id: id },
            success: function () {
                $("#popupModal").modal("hide");
                location.reload();
            }
        })
    })

})