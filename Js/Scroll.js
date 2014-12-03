$(window).load(function() {
visibleHeight=$('#customScrollBox').height();

if($('#customScrollBox  .container').height()>visibleHeight){

totalContent=$('#customScrollBox  .content').height();

minDraggerHeight=$('#dragger').height();

draggerContainerHeight=$('#dragger_container').height();

adjDraggerHeight=totalContent-((totalContent-visibleHeight)*1.3); //adjust dragger height analogous to content

if(adjDraggerHeight>minDraggerHeight){ //minimum dragger height

$('#dragger').css('height',adjDraggerHeight+'px');

$('#dragger').css('line-height',adjDraggerHeight+'px');

} else {

$('#dragger').css('height',minDraggerHeight+'px');

$('#dragger').css('line-height',minDraggerHeight+'px');

}

if(adjDraggerHeight<$('#dragger_container').height()){

$('#dragger').css('top',mouseCoord);

Scroll();
} else {

$('#dragger').css('top',$('#dragger_container').height()-$('#dragger').height());

Scroll();

}

});

//mousewheel

$(function($) {

$('#customScrollBox').bind('mousewheel', function(event, delta) {

vel = Math.abs(delta*10);

$('#dragger').css('top', $('#dragger').position().top-(delta*vel));

Scroll();

if($('#dragger').position().top<0){

$('#dragger').css('top', 0);

$('#customScrollBox .container').stop();

Scroll();

}

if($('#dragger').position().top>$('#dragger_container').height()-$('#dragger').height()){

$('#dragger').css('top', $('#dragger_container').height()-$('#dragger').height());

$('#customScrollBox .container').stop();

Scroll();

}

return false;

});

});

function Scroll(){

var scrollAmount=(totalContent-(visibleHeight/bottomSpace))/(draggerContainerHeight-draggerHeight);

var draggerY=$('#dragger').position().top;

targY=-draggerY*scrollAmount;

var thePos=$('#customScrollBox  .container').position().top-targY;

$('#customScrollBox .container').css('top',$('#customScrollBox  .container').position().top-thePos+'px'); //no easing

}

$("#dragger").mouseup(function(){

DraggerOut();

}).mousedown(function(){

DraggerOver();

});

function DraggerOver(){

$('#dragger').css('background-color', '#ccc');

$('#dragger').css('color', '#666');

$('#dragger').css('border-left-color', '#fff');

$('#dragger').css('border-right-color', '#555');

}

function DraggerOut(){

$('#dragger').css('background-color', '#999');
$('#dragger').css('color', '#666');

$('#dragger').css('border-left-color', '#ccc');

$('#dragger').css('border-right-color', '#555');

}

} else {

$('#dragger').css('display','none');

$('#dragger_container').css('display','none');

}

});