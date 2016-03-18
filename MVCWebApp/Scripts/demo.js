// Code is executed right after the document is finished loading
$(function(){

    $('button.example').click(function(){
        //debugger;
        var exampleID = $(this).attr('for');
        toggleExample(exampleID);
        //showExample(exampleID);
    });

    $('button.copytoclipboard').click(function(){
        //debugger;
        var copyExampleID = $(this).attr('id');
        copyToClipboard(copyExampleID);
    });


});


// Functions, lots of them...

function toggleExample(exampleID) {
    //debugger;
    //var example = codeBlock;
    var hasClassHide = $('#'+exampleID).hasClass('hide-code-block');

    if (hasClassHide) {
        $('#'+exampleID).removeClass('hide-code-block');
        $('#but-'+exampleID+'.hide-code-button').removeClass('hide-code-button');
        $('.copytoclipboard-wrapper').addClass('pad-btm-lg');
    }
    else {
        $('#'+exampleID).addClass('hide-code-block');
        $('#but-'+exampleID+'').addClass('hide-code-button');
        $('.copytoclipboard-wrapper').removeClass('pad-btm-lg');
    }
};


function copyToClipboard(copyExampleID) {
    //debugger;
    var id = "'#but-inputs'"

    var copyCode = new Clipboard('button.copytoclipboard', {
        target: function (trigger) {
            return trigger.previousElementSibling;
        }
    });

    copyCode.on('success', function (event) {
        event.clearSelection();
        event.trigger.textContent = 'Code copied';
        window.setTimeout(function () {
            event.trigger.textContent = 'Copy code';
        }, 1000);
    });

    copyCode.on('error', function (event) {
        event.trigger.textContent = 'Press "Ctrl + C" to copy';
        window.setTimeout(function () {
            event.trigger.textContent = 'Copy code';
        }, 1000);
    });
};





