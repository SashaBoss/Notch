var Product = Product || {};

(function() {
    var self = this;

    self.Initialize = function (products) {
        var vmProducts = [];
        products.forEach(function(p) {
            vmProducts.push(new Product(p.Id, p.Name, p.Price, p.Discount))
        });
        ko.applyBindings(new ProductVM(products));
    }

}).apply(Product);

function ProductVM(products) {
    var self = this;

    self.AvailableProducts = products;

    self.SetSelected = function() {
        var p = this;
    }

    self.SelectedProduct = ko.observable({});
}

function Product(id, name, price, discount) {
    var self = this;
    self.Id = id || 0;
    self.Name = name || "";
    self.Price = price || 0;
    self.Discount = discount || 0;

    self.TotalPrice = ko.computed(function () {
        return self.Price * self.Discount;
    });
}