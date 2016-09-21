
$(document).ready(function () {
    updateClock(); 
});

function timenow(){
    var now= new Date(), 
    ampm= 'am', 
    h= now.getHours(), 
    m= now.getMinutes(), 
    s= now.getSeconds();
    if(h>= 12){
        if(h>12) h -= 12;
        ampm= 'pm';
    }

    if(m<10) m= '0'+m;
    if(s<10) s= '0'+s;
    return now.toLocaleDateString()+ ' ' + h + ':' + m + ' ' + ampm;
}

function updateClock() {
    var datetime = timenow();
    $("#lblDatetime").text(datetime);

    // call this function again in 1000ms
    setTimeout(updateClock, 1000);
}
