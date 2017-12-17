var Track = Track || {};

(function () {
    var self = this;

    function setEditFormValues(track) {
        var $editForm = $(self.createEditFormSelector);
        $editForm.find('#Id').val(track.Id);
        $editForm.find('#Name').val(track.Name);
        $editForm.find('#Length').val(track.Length);
        $editForm.find('#BPM').val(track.BPM);
    }

    function emptyEditFromValues() {
        var $editForm = $(self.createEditFormSelector);
        $editForm.find('#Id').val(0);
        $editForm.find('#Name').val('');
        $editForm.find('#Length').val(0);
        $editForm.find('#BPM').val(0);
    }

    function Track(id, name, length, bpm) {
        this.Id = id || 0;
        this.Name = name || '';
        this.Length = length || 0;
        this.BPM = bpm || 0;
    }

    function bindEvents() {
        $(document).on('click', '.btn-cancel', function () {
            self.closeForm();
        });

        $(document).on('click', '.create-track-btn', function () {
            emptyEditFromValues();
        });

        $(document).on('click', '.btn-edit-track', function () {
            var $this = $(this);
            var track = new Track(
                $this.data('track-id'),
                $this.data('track-name'),
                $this.data('track-length'),
                $this.data('track-bpm'));
            setEditFormValues(track);
            $(self.createEditFormSelector).collapse('show');
        });
    }

    self.createEditFormSelector = '#createEditForm';

    self.closeForm = function () {
        $(self.createEditFormSelector).collapse('hide');
    }

    self.init = function () {
        bindEvents();
    }
}).apply(Track);