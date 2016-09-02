function carouselPrev(selector) {
    var owl = $(selector).data('owlCarousel');
    owl.prev();
}

function carouselNext(selector) {
    var owl = $(selector).data('owlCarousel');
    owl.next();
}