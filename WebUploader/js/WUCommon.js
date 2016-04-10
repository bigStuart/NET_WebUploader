/**
 * Created by ZYMAppOne on 2016/4/10.
 */
function initDIV(id){
    var mId = "#"+id;
    var mDivs = ""+
        "<div id='wrapper'>"+
            "<div id='container'>"+
                "<div id='uploader'>"+
                    "<div class='queueList'>"+
                        "<div id='dndArea' class='placeholder'>"+
                            "<div><img src='image/image.png' width='80' height='70'></div>"+
                            "<div id='filePicker'></div>"+
                        "</div>"+
                    "</div>"+
                    "<div class='statusBar' style='display:none;'>"+
                        "<div class='progress'>"+
                            "<span class='text'>0%</span>"+
                            "<span class='percentage'></span>"+
                        "</div>" +
                        "<div class='info'></div>"+
                        "<div class='btns'>"+
                            "<div id='filePicker2'></div><div class='uploadBtn'>开始上传</div>"+
                        "</div>"+
                    "</div>"+
                "</div>"+
            "</div>"+
        "</div>";
    $(mId).append(mDivs);
}