var postApiUrl = '/api/WallPost/', commentApiUrl = '/api/Comment/';
// Model
function Post(data) {
    var self = this;
    data = data || {};
    self.PostId = data.ID;
    self.Message = ko.observable(data.Body || "");
    self.PostedBy = data.SenderID || "";
    self.PostedByName = data.UserName || "";
    self.PostedDate = getTimeAgo(data.Date);
    self.error = ko.observable();
    
        
        return $.ajax({
            url: commentApiUrl,
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'POST',
            data: ko.toJSON(comment)
        })
        .done(function (result) {
            self.PostComments.push(new Comment(result));
            self.newCommentMessage('');
        })
        .fail(function () {
            error('unable to add post');
        });
    }
    if (data.PostComments) {
        var mappedPosts = $.map(data.PostComments, function (item) { return new Comment(item); });
        self.PostComments(mappedPosts);
    }
    self.toggleComment = function (item, event) {
        $(event.target).next().find('.publishComment').toggle();
    }
}