var VM = function () {

    var self = this;


    self.Contacts = ko.observableArray([]);
    GetContacts();

    self.ContactsLocal = ko.observableArray(JSON.parse(localStorage.getItem('contacts')) || []);

    self.IsOnline = ko.observable(true);

    self.Save = function () {

        var contactName = $('#contact').val();

        if (self.IsOnline()) {

            SaveToServer(contactName);

        }
        else {
            // offline
            self.ContactsLocal.push(contactName);
            localStorage.setItem('contacts', JSON.stringify(self.ContactsLocal()));
        }
    }

    self.SaveLocal = function () {

        var contacts = JSON.parse(localStorage.getItem('contacts'));

        $.each(contacts, function () {
            SaveToServer(this);
        });

        localStorage.clear();
        self.ContactsLocal([]);
    }
};

var vm = new VM();
ko.applyBindings(vm);

function SaveToServer(contactName) {

    $.ajax({

        type: 'POST',
        url: '/contact/save',
        data: { name: contactName },
        dataType: "json",
        success: function (contact) {

            toastr.success('Successfully saved to server!');
            GetContacts();
        }
    });
}

function GetContacts() {

    $.ajax({

        url: '/Contact/GetAll',
        success: function (data) {

            vm.Contacts(data);
        },
        error: function () {

            vm.IsOnline(false);
        }
    })

}
