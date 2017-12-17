var Track = Track || {};

(function () {
    var self = this;

    function bindEvents() {
        $(document).on('click', '.btn-cancel', function () {
            self.closeForm();
        });
    }

    self.createFormSelector = '#createForm';

    self.closeForm = function() {
        $(self.createFormSelector).collapse('hide');
    }

    self.init = function() {
        bindEvents();
    }
}).apply(Track);