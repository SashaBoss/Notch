var Product = Product || {};

(function() {
    var self = this;

    self.Initialize = function (products) {
        var vmProducts = [];
        products.forEach(function(p) {
            vmProducts.push(new Product(p.Id, p.Name, p.Price, p.Discount));
        });

        ko.applyBindings(new ShopVM(vmProducts));
    }

}).apply(Product);

function ShopVM(products) {
    var self = this;

    self.AvailableProducts = products;
    self.SelectedProduct = ko.observable({});
    self.NewOrder = ko.observable(new NewOrder());
    self.ShippedOrders = ko.observableArray();

    self.AddToOrder = function () {
        self.NewOrder().Products.push(self.SelectedProduct());
    }

    self.ShipOrder = function () {
        self.ShippedOrders.push(this.NewOrder);
    }
}

function Product(id, name, price, discount) {
    var self = this;
    self.Id = id || 0;
    self.Name = name || "";
    self.Price = price || 0;
    self.Discount = ko.observable(discount);

    self.DiscountPrice = ko.computed(function () {
        return self.Price - (self.Price * self.Discount() /100);
    });
}

function NewOrder() {
    var self = this;

    self.Products = ko.observableArray();
    self.OrderTotal = ko.computed(function() {
        var total = 0;

        self.Products().forEach(function(product) {
            total += product.DiscountPrice();
        });

        return total;
    });

    self.ProductsCount = ko.computed(function () {
        return self.Products().length;
    });

    self.RemoveProduct = function () {
        self.Products.remove(this);
    }
}