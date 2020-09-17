var Suppliers = Suppliers || {};

Suppliers.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn có muốn xóa nhân viên này không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.deleSupplier > 0) {
                            window.location.href = "/Product/listSupplier";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#tbList").dataTable();
});