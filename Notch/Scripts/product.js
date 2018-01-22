var Product = Product || {};

(function() {
    var self = this;

    self.Initialize = function(products) {
        ko.applyBindings(new ProductVM(products));
    }

}).apply(Product);

function ProductVM(products) {
    var self = this;

    self.AvailableProducts = products;
}

function Product(id, name, price, discount) {
    this.Id = id || 0;
    this.Name = name || "";
    this.Price = price || 0;
    this.Discount = discount || 0;
}