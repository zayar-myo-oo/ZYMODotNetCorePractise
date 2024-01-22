//Eyes
const retina = $(".eye-retina");
const button = $(".eyes");

$(document).mousemove((e) => {
    e = e || window.event;

    //Offset of button from document
    const rect = button[0].getBoundingClientRect();
    const offsetLeft = rect.left + window.pageXOffset;
    const offsetTop = rect.top + window.pageYOffset;

    //Position of cursor in pixel
    const pageX = e.pageX;
    const pageY = e.pageY;

    //Cursor left position relative to button
    let left = (pageX - offsetLeft) / rect.width * 100;

    //Cursor top position relative to button
    let top = (pageY - offsetTop) / rect.height * 100;

    //Prevent the eye from getting hidden at the left and right end.
    left = left < 25 ? 25 : left;
    left = left > 75 ? 75 : left;

    //Prevent the eye from getting hidden at the top and bottom end.
    top = top < 25 ? 25 : top;
    top = top > 75 ? 75 : top;

    //Move the eye
    retina.each((i, f) => {
        //If the cursor is in center of both the eyes the keep the eye in center
        f.style.left = `${left > 45 && left < 55 ? 50 : left}%`;
        f.style.top = `${top > 45 && top < 55 ? 50 : top}%`;
    });
});
