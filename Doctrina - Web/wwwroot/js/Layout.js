
function CreateSearchHref() {
    var url = '/search';
    var searchText = $('#searchBar').val();
    console.log(window.location.href);
    window.location.href = url + '/' + searchText;
}