function onlineCheck() {

    $.ajax({
        url: '/home/validateonline',
        timeout: 4000,
        success: function (msg) {

            // online
            checkOnline();
        },
        error: function () {

            // offline
            checkOnline();
        }
    });
}

onlineCheck();
function checkOnline() {
    setTimeout(onlineCheck, 5000);
}

$(document).on('online offline', function (e) {

    vm.IsOnline(e.type === 'online');
});


$(window.applicationCache).on('updateready', function (e) {

    if (window.applicationCache.status == window.applicationCache.UPDATEREADY) {

        //update cache
        window.applicationCache.swapCache();

        // cache has been updated, ensure they want to see the goodness
        if (confirm('A new version is available. Load it?')) {

            location.reload();
        }
    }
});