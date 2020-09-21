

var itemsList = [];
$(function () {
    $("#add").click(function () {
        var isValid = true;

        if (document.getElementById("productsItems").selectedIndex == 0) {
            $('#productsItems').siblings('span.error').text('Please select item');
            isValid = false;
        }
        else {
            $('#productsItems').siblings('span.error').text('');
        }
        if (!($("#quantity").val().trim() != '' & (parseInt($("#quantity").val()) || 0))) {
            $('#quantity').siblings('span.error').text('Please enter quantity');
            isValid = false;
        }
        else {
            $('#quantity').siblings('span.error').text('');
        } if (!($("#price").val().trim() != '' & (parseFloat($("#price").val()) || 0))) {
            $('#price').siblings('span.error').text('Please enter price');
            isValid = false;
        }
        else {
            $('#price').siblings('span.error').text('');
        }

        if (isValid) {
            var total = parseInt($('#quantity').val()) * parseFloat($('#price').val());
           
            $("#total").val(total);

            var ProductId = document.getElementById('productsItems').value;

            
            var item = {
                productid: ProductId,
                TotalPrice: total,
                Price: parseFloat($('#price').val()),
                Quantity: parseInt($('#quantity').val())
            }
            itemsList.push(item);

            var $newRow = $("#MainRow").clone().removeAttr('id');

            $('#productsItems', $newRow).val(ProductId);

            $('#add', $newRow).addClass('remove').html('<span class=\"fa fa-minus-circle\"></span> Remove').removeClass('btn-success').addClass("btn-danger");

            $("#productsItems, #quantity", $newRow).attr('disabled', true);

            $("#productsItems, #quantity, #price, #total", $newRow).removeAttr('id');

            $("span.error", $newRow).remove();

            $("#OrderItems").append($newRow[0]);

            document.getElementById("productsItems").selectedIndex = 0;
            $('#price').val();
            $('#quantity').val();
            $('#total').val();
        }
    });

    $("#productsItems").on("click", ".remove", function () {
        $(this).parents("tr").remove();
    });
    
    $("#submit").click(function () {
        var isValid = true;

       

        //$("#OrderItems tr").each(function () {
        //    var item = {
        //        productid: $('#productsItems', this).val(),
        //        Price: $('#price', this).val(),
        //        Quantity: $('#quantity', this).val(),
        //        TotalPrice: $('#total', this).val()
                
        //    }
        //    console.log(item);
        //    itemsList.push(item);
        //});
        
        console.log(itemsList);
        if (isValid) {
            let dataObject = {
                Date: $("#date").val(),
                Items: itemsList
            }
            debugger;
            $("#submit").attr("disabled", true);
            $("#submit").html('Please wait...');
            //$("#submit").html('Please wait...');
            console.log(dataObject);
            $.ajax({
                type: 'POST',
                url: '/Oder/AddOrderAndOrderDetails',
                //dataType: 'json',
                data: JSON.stringify(dataObject),
                contentType: 'application/json',
               
                success: function (data) {
                    if (data.status == true) {
                        $('#orderMessage').text(data.message);
                    }
                    else {
                        $('#orderMessage').text(data.message);
                    }
                }
            })
        }
    });
});