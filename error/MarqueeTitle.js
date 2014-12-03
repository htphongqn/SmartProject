var txt = " ..:: WelCome To Website | Multi - Design & Innovation Technology | MDIT | © ::..";
var expert = 200;
// speed of roll
var refresh = null;
function marquee_title() {
    document.title = txt;
    txt = txt.substring(1, txt.lenghth) + txt.charAt(0);
    refresh = setTimeout("marquee_title()", expert);
}
marquee_title();