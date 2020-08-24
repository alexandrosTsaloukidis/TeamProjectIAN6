let FollowingService = function () {
    let createFollowing = function (userId, done, fail) {
        $.post("/api/FollowRestaurnts", { userId: userId })
            .done(done)
            .fail(fail);
    };

    let deleteFollowing = function (userId, done, fail) {
        $.ajax({
            url: "/api/FollowRestaurnts/" + userId,
            method: "Delete"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    };
}();