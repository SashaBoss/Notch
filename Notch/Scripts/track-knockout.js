var TrackKO = TrackKO || {};

(function () {
    var self = this;

    self.init = function(tracks) {
        var vm = new TrackViewModel(tracks);
        ko.applyBindings(vm);
    }

    function TrackViewModel(tracks) {
        var self = this;

        self.tracks = tracks;
    }

}).apply(TrackKO);