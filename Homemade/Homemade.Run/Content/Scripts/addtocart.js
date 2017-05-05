var url = "@Url.Action('AddToCart', 'ShoppingCart')";

function addItem(productId){
    $.ajax({
        type: 'POST',
        data: { productId: productId },
        url: url,
        success: function () {
            $.notify(
                 "Product added in the Shopping Cart!",
                 {
                     position: "right bottom", className: "success"
                 }
            );
        }
    });
};