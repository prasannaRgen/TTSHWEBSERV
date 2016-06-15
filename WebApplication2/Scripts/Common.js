//------------Open Modal Dialog

function ShowModalPopup(divId) {
    $('#' + divId + '').showModal();
    return false
}
function HideModalPopup(divId) {
    $('#' + divId + '').hideModal();
    return false
}
function chkNonCharacterKey(e) {
    var code = e;
    if (code == Sys.UI.Key.enter || code == Sys.UI.Key.esc) { // allow RETURN/ENTER and ESC keys for all browsers
        return true;
    }
    else if (Sys.Browser.agent == Sys.Browser.Safari && Sys.Browser.version < 500) {
        if (code == 8           // BACKSPACE in Safari 2
                || code == 9        // TAB in Safari 2
                || code == 63272    // DELETE in Safari 2
                || code == 63276    // PAGEUP in Safari 2
                || code == 63277    // PAGEDOWN in Safari 2
                || code == 63275    // END in Safari 2
                || code == 63273    // HOME in Safari 2
                || code == 63234    // ARROWLEFT in Safari 2
                || code == 63235    // ARROWRIGHT in Safari 2
                || (code >= 63236 && code <= 63243) // FUNCTION keys in Safari 2
                || code == 63248       // F13 key in Safari 2
            ) {
            return true;
        }
    }
    else if (Sys.Browser.agent == Sys.Browser.WebKit) {
        if (code == 8            // BACKSPACE in Safari 3
                || code == 9         // TAB in Safari 3
                || code == 19        // PAUSE BREAK Safari 3
                || code == 33        // PAGEUP in Safari 3
                || code == 34        // PAGEDOWN in Safari 3
                || code == 35        // END in Safari 3
                || code == 36        // HOME in Safari 3
                || code == 37        // ARROWLEFT in Safari 3
                || code == 39        // ARROWRIGHT in Safari 3
                || code == 45        // INSERT in Safari 3
                || code == 46        // DELETE in Safari 3
                || code == 91        // WINDOWS LEFT Safari 3
                || code == 92        // WINDOWS RIGHT Safari 3
                || code == 93        // MENU Safari 3
                || code == 113       // F2 Safari 3
                || code == 115       // F4 Safari 3
                || code == 118       // F7 Safari 3
                || code == 119       // F8 Safari 3
                || code == 120       // F9 Safari 3
                || code == 122       // F11 Safari 3
                || code == 145       // SCROLL LOCK Safari 3
            )
            return true;
    }
    else if (Sys.Browser.agent != Sys.Browser.InternetExplorer) {
        if (code == 8           // BACKSPACE in non-microsoft browsers
                || code == 9        // TAB in non-microsoft browsers
                || code == 33       // PAGEUP in non-microsoft browsers
                || code == 34       // PAGEDOWN in non-microsoft browsers
                || code == 35       // END in non-microsoft browsers
                || code == 36       // HOME in non-microsoft browsers
                || code == 37       // ARROWLEFT in non-microsoft browsers
                || code == 39       // ARROWRIGHT in non-microsoft browsers
                || code == 45       // INSERT in non-microsoft browsers
                || code == 46       // DELETE in non-microsoft browsers
            ) {
            if (!e.shiftKey)
                return true;
        }
        else if (code == 145) {
            return true;
        }
        else if (code == 19) {
            return true;
        }
        else if (Sys.Browser.agent == Sys.Browser.Opera) {
            if (code == 0       // MENU key in Opera
                    || code == 16   // SHIFT key in Opera
                    || code == 17   // CONTROL key in Opera
                ) {
                return true;
            }
        }
        else if (Sys.Browser.agent == Sys.Browser.Firefox) {
            if (code == 91      // WINDOWS LEFT key in Firefox
                    || code == 92   // WINDOWS RIGHT key in Firefox
                    || code == 93   // MENU key in Firefox
                ) {
                return true;
            }
        }
    }
    return false;
}
function chkDecimalPoint(e, obj) {
    var chrCode = (e.which) ? e.which : event.keyCode
    if (chrCode == 46) {
        if (("@" + obj.value).indexOf(".") < 0)
            return true;
        else
            return false;
    }
    return chkNumber(e, obj)
}
function chkAlphaNumeric(e, obj) {
    var key;
    if (e.keyCode) key = e.keyCode;
    else if (e.which) key = e.which;
    if (/[^A-Za-z0-9_]/.test(String.fromCharCode(key)))
        return false;
    else
        return true;
}
function chkSeparator(e, obj) {
    var key;
    if (e.keyCode) key = e.keyCode;
    else if (e.which) key = e.which;
    if (/[^A-Za-z0-9]/.test(String.fromCharCode(key)))
        return true;
    else
        return false;
}
function getCursorPos(textElement) {
    //save off the current value to restore it later, 
    var sOldText = textElement.value;
    //create a range object and save off it's text
    var objRange = document.selection.createRange();
    var sOldRange = objRange.text;
    //set this string to a small string that will not normally be encountered
    var sWeirdString = '#%~';
    //insert the weirdstring where the cursor is at
    objRange.text = sOldRange + sWeirdString; objRange.moveStart('character', (0 - sOldRange.length - sWeirdString.length));
    //save off the new string with the weirdstring in it
    var sNewText = textElement.value;
    //set the actual text value back to how it was
    objRange.text = sOldRange;
    //look through the new string we saved off and find the location of
    //the weirdstring that was inserted and return that value
    for (i = 0; i <= sNewText.length; i++) {
        var sTemp = sNewText.substring(i, i + sWeirdString.length);
        if (sTemp == sWeirdString) {
            var cursorPos = (i - sOldRange.length);
            return cursorPos;
        }
    }
}
function chkMultiDecimalPoint(e, obj) {
    var chrCode = (e.which) ? e.which : event.keyCode
    var bol = false;
    if (chrCode == 46) {
        if (obj.value.length > 0) {
            var txt = obj.value;
            var str = '';
            var k = 2;
            var i;
            for (i = 0; i <= k; i++) {
                if (txt.charAt(k - i) == '+' || txt.charAt(k - i) == '-' || txt.charAt(k - i) == '*' || txt.charAt(k - i) == '/' || txt.charAt(k - i) == '(' || txt.charAt(k - i) == ')') {
                    bol = true;
                    if (k <= txt.length) {
                        for (j = k + 1; j <= txt.length; j++) {
                            if (txt.charAt(j) == '+' || txt.charAt(j) == '-' || txt.charAt(j) == '*' || txt.charAt(j) == '/' || txt.charAt(j) == '(' || txt.charAt(j) == ')') {
                                j = txt.length;
                                i = k;
                            } else {
                                if (txt.charAt(j) == '.')
                                    return false;
                                else
                                    str = str + txt.charAt(j);
                            }
                        }
                    } else {
                        i = k;
                    }
                } else {
                    if (txt.charAt(k - i) == '.')
                        return false;
                    else
                        str = txt.charAt(k - i) + str;
                }
            }
        } else {
            if (("@" + obj.value).indexOf(".") <= 0) {
                obj.value = "0.";
                return false;
            } else
                return false;
        }
        if (k <= txt.length && bol == false) {
            for (j = k + 1; j <= txt.length; j++) {
                if (txt.charAt(j) == '+' || txt.charAt(j) == '-' || txt.charAt(j) == '*' || txt.charAt(j) == '/' || txt.charAt(j) == '(' || txt.charAt(j) == ')') {
                    j = txt.length;
                    i = k;
                } else {
                    if (txt.charAt(j) == '.')
                        return false;
                    else
                        str = str + txt.charAt(j);
                }
            }
        } else {
            i = k;
        }
        alert('String : ' + str + ' ; Pointer : ' + k);
    }
}
function chkNumber(e, obj) {
    var chrCode = (e.which) ? e.which : event.keyCode
    return (chrCode > 47 && chrCode < 58)
	         || chkNonCharacterKey(e) ? true : false;
}
function CloseModelPopUp(divid) {
    var out = confirm('Are you sure ?\n You want to cancel !!.');
    if (out) {
        $('#' + divid + '').hideModal();
    }
    return false;
}
function FunKeyDown(event, obj) {
    var code = (event.which) ? event.which : event.keyCode;
    var character = String.fromCharCode(code);
    var objid = null;
    var elem1 = null;
    if (obj.tagName == "TEXTAREA") { return true; }
    if (obj.tagName == "SPAN") { objid = obj.childNodes[0].id; } else { objid = obj.id; }
    if (obj.type == 'submit') { return true; }
    if (obj.type == 'image') { return true; }
    if (code == 13) {
        var findit = false
        var elem = document.all;
        for (var i = 0; i < elem.length; i++) {
            elem1 = elem[i];
            if ((elem1.type != "hidden") && (elem1.style.display != "none")) {
                if (findit) {
                    if ((elem1.tagName == "TEXTAREA" || elem1.tagName == "INPUT" || elem1.tagName == "SELECT")) {
                        if (!elem1.isDisabled) {
                            if (elem1.tagName != "SELECT") {
                                if (elem1.readOnly == false) {
                                    if (!elem1.disabled) {
                                        elem1.focus(); break;
                                    }
                                }
                            } else {
                                if (!elem1.disabled) {
                                    elem1.focus(); break;
                                }
                            }
                        }
                        else {
                            if (elem1.isDisabled == false) {
                                elem1.focus(); break;
                            }
                        }
                    }
                }
                if (elem1.id == objid) {
                    findit = true;
                }
            }
        }
        return false;
    }
    else {
        return true;
    }
}
function IE_keydown() {
    var t = event.srcElement.type;
    var kc = event.keyCode;
    if (kc == 13)
        return FunKeyDown(event, event.srcElement);
    return ((kc != 8) || (t == 'text') || (t == 'textarea') || (t == 'submit') || (t == 'password'))
}
function Other_keypress(e) {
    var t = e.target.type;
    var kc = e.keyCode;
    if (kc == 13) {
        return FunKeyDown(e, e.target);
    }
    if ((kc != 8) || (t == 'text') ||
            (t == 'textarea') || (t == 'submit') || (t == 'password'))
        return true
    else {
        alert('Sorry Backspace/Enter is not allowed here'); // Demo code
        return false
    }
}
function ValidLength(obj, Length) {
    var control = document.getElementById(obj.id);
    var Text = obj.value;
    if (Text.length > Length) {
        alert("You can not enter more then " + Length + " character.\nYou already enter " + Text.length + " character");
        if (control.disabled == false) {
            control.focus();
        }
        return false;
    }
    else {
        return true;
    }
}
function limitTextarea(textarea, maxLines, maxChar) {
    var lines = textarea.value.replace(/\r/g, '').split('\n'), lines_removed, char_removed, i;
    if (maxLines && lines.length > maxLines) {
        ShowMsg('You can not enter more than ' + maxLines + ' lines');
        if (textarea.value.substr(textarea.selectionStart - 1, 1) == '\n') {
            if (textarea.selectionStart == textarea.value.length) {
                textarea.value = textarea.value.substr(0, textarea.selectionStart - 1)
            }
            else {
                textarea.value = textarea.value.substr(0, textarea.selectionStart - 1) + textarea.value.substr(textarea.selectionStart)
            }
        }
        lines = textarea.value
        //lines = lines.slice(0, maxLines);
        //lines_removed = 1
    }
    if (maxChar) {
        i = lines.length;
        while (i-- > 0) if (lines[i].length > maxChar) {
            lines[i] = lines[i].slice(0, maxChar);
            //lines[i] = lines[i].slice(0, textarea.selectionStart - ((maxChar * (i + 1)) - (i + 2))) + lines[i].slice(textarea.selectionStart - ((maxChar * (i + 1)) - (i + 2) + 1));
            char_removed = 1
        }
        if (char_removed) ShowMsg('You can not enter more than ' + maxChar + ' characters per line', "Sky™ WEB ERP");
    }
    if (char_removed || lines_removed) textarea.value = lines.join('\n')
}
//For DatePicker Control------------------------------------------------------------------------------------
function chkDateOnBlur(obj, min, max) {
    var format = "dd/MM/yyyy";
    var dtCont = obj;
    //    var min = "01/04/2011";
    //    var max = "31/03/2012";
    var dtTxt = dtCont.value;
    var sCount = 0;
    var nwTxt = '';
    var bol = false;
    if (dtTxt != "") {
        //If Only One Text Enter/------------------------------------
        if (dtTxt.split(".").length >= 3 && bol == false) {
            if (dtTxt.split(".")[0].length == 1)
                nwTxt += "0" + dtTxt.split(".")[0];
            else
                nwTxt += dtTxt.split(".")[0];
            if (dtTxt.split(".")[1].length == 1)
                nwTxt += "0" + dtTxt.split(".")[1];
            else
                nwTxt += dtTxt.split(".")[1];
            if (dtTxt.split(".").length == 3) nwTxt += dtTxt.split(".")[2];
            bol = true;
        }
        if (dtTxt.split("-").length >= 3 && bol == false) {
            if (dtTxt.split("-")[0].length == 1)
                nwTxt += "0" + dtTxt.split("-")[0];
            else
                nwTxt += dtTxt.split("-")[0];
            if (dtTxt.split("-")[1].length == 1)
                nwTxt += "0" + dtTxt.split("-")[1];
            else
                nwTxt += dtTxt.split("-")[1];
            if (dtTxt.split("-").length == 3) nwTxt += dtTxt.split("-")[2];
            bol = true;
        }
        if (dtTxt.split("/").length >= 3 && bol == false) {
            if (dtTxt.split("/")[0].length == 1)
                nwTxt += "0" + dtTxt.split("/")[0];
            else
                nwTxt += dtTxt.split("/")[0];
            if (dtTxt.split("/")[1].length == 1)
                nwTxt += "0" + dtTxt.split("/")[1];
            else
                nwTxt += dtTxt.split("/")[1];
            if (dtTxt.split("/").length == 3) nwTxt += dtTxt.split("/")[2];
            bol = true;
        }
        if (!bol) {
            if (dtTxt.split(".").length >= 2) {
                if (dtTxt.split(".")[0].toString().indexOf("/") >= 1 || dtTxt.split(".")[0].toString().indexOf("-") >= 1) {
                    if (dtTxt.split(".")[0].toString().split("-").length >= 2) {
                        if (dtTxt.split(".")[0].toString().split("-")[0].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[0].toString().split("-")[0];
                        else
                            nwTxt += dtTxt.split(".")[0].toString().split("-")[0];
                    }
                    if (dtTxt.split(".")[0].toString().split("-").length >= 2) {
                        if (dtTxt.split(".")[0].toString().split("-")[1].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[0].toString().split("-")[1];
                        else
                            nwTxt += dtTxt.split(".")[0].toString().split("-")[1];
                    }
                    if (dtTxt.split(".")[0].toString().split("/").length >= 2) {
                        if (dtTxt.split(".")[0].toString().split("/")[0].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[0].toString().split("/")[0];
                        else
                            nwTxt += dtTxt.split(".")[0].toString().split("/")[0];
                    }
                    if (dtTxt.split(".")[0].toString().split("/").length >= 2) {
                        if (dtTxt.split(".")[0].toString().split("/")[1].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[0].toString().split("/")[1];
                        else
                            nwTxt += dtTxt.split(".")[0].toString().split("/")[1];
                    }
                    if (dtTxt.split(".")[1].length == 1)
                        nwTxt += "0" + dtTxt.split(".")[1];
                    else
                        nwTxt += dtTxt.split(".")[1];
                }
                if (dtTxt.split(".")[1].toString().indexOf("/") >= 1 || dtTxt.split(".")[1].toString().indexOf("-") >= 1) {
                    if (dtTxt.split(".")[0].length == 1)
                        nwTxt += "0" + dtTxt.split(".")[0];
                    else
                        nwTxt += dtTxt.split(".")[0];
                    if (dtTxt.split(".")[1].toString().split("-").length >= 2) {
                        if (dtTxt.split(".")[1].toString().split("-")[0].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[1].toString().split("-")[0];
                        else
                            nwTxt += dtTxt.split(".")[1].toString().split("-")[0];
                    }
                    if (dtTxt.split(".")[1].toString().split("-").length >= 2) {
                        if (dtTxt.split(".")[1].toString().split("-")[1].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[1].toString().split("-")[1];
                        else
                            nwTxt += dtTxt.split(".")[1].toString().split("-")[1];
                    }
                    if (dtTxt.split(".")[1].toString().split("/").length >= 2) {
                        if (dtTxt.split(".")[1].toString().split("/")[0].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[1].toString().split("/")[0];
                        else
                            nwTxt += dtTxt.split(".")[1].toString().split("/")[0];
                    }
                    if (dtTxt.split(".")[1].toString().split("/").length >= 2) {
                        if (dtTxt.split(".")[1].toString().split("/")[1].length == 1)
                            nwTxt += "0" + dtTxt.split(".")[1].toString().split("/")[1];
                        else
                            nwTxt += dtTxt.split(".")[1].toString().split("/")[1];
                    }
                }
                if (!(dtTxt.split(".")[1].toString().indexOf("/") >= 1 || dtTxt.split(".")[1].toString().indexOf("-") >= 1 || dtTxt.split(".")[0].toString().indexOf("/") >= 1 || dtTxt.split(".")[0].toString().indexOf("-") >= 1)) {
                    if (dtTxt.split(".")[0].length == 1)
                        nwTxt += "0" + dtTxt.split(".")[0];
                    else
                        nwTxt += dtTxt.split(".")[0];
                    if (dtTxt.split(".")[1].length == 1)
                        nwTxt += "0" + dtTxt.split(".")[1];
                    else
                        nwTxt += dtTxt.split(".")[1];
                }
            } else {
                if (dtTxt.split("/").length >= 2) {
                    if (dtTxt.split("/")[0].toString().indexOf("-") >= 1 || dtTxt.split("/")[0].toString().indexOf(".") >= 1) {
                        if (dtTxt.split("/")[0].toString().split(".").length >= 2) {
                            if (dtTxt.split("/")[0].toString().split(".")[0].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[0].toString().split(".")[0];
                            else
                                nwTxt += dtTxt.split("/")[0].toString().split(".")[0];
                        }
                        if (dtTxt.split("/")[0].toString().split(".").length >= 2) {
                            if (dtTxt.split("/")[0].toString().split(".")[1].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[0].toString().split(".")[1];
                            else
                                nwTxt += dtTxt.split("/")[0].toString().split(".")[1];
                        }
                        if (dtTxt.split("/")[0].toString().split("-").length >= 2) {
                            if (dtTxt.split("/")[0].toString().split("-")[0].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[0].toString().split("-")[0];
                            else
                                nwTxt += dtTxt.split("/")[0].toString().split("-")[0];
                        }
                        if (dtTxt.split("/")[0].toString().split("-").length >= 2) {
                            if (dtTxt.split("/")[0].toString().split("-")[1].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[0].toString().split("-")[1];
                            else
                                nwTxt += dtTxt.split("/")[0].toString().split("-")[1];
                        }
                        if (dtTxt.split("/")[1].length == 1)
                            nwTxt += "0" + dtTxt.split("/")[1];
                        else
                            nwTxt += dtTxt.split("/")[1];
                    }
                    if (dtTxt.split("/")[1].toString().indexOf("-") >= 1 || dtTxt.split("/")[1].toString().indexOf(".") >= 1) {
                        if (dtTxt.split("/")[0].length == 1)
                            nwTxt += "0" + dtTxt.split("/")[0];
                        else
                            nwTxt += dtTxt.split("/")[0];
                        if (dtTxt.split("/")[1].toString().split(".").length >= 2) {
                            if (dtTxt.split("/")[1].toString().split(".")[0].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[1].toString().split(".")[0];
                            else
                                nwTxt += dtTxt.split("/")[1].toString().split(".")[0];
                        }
                        if (dtTxt.split("/")[1].toString().split(".").length >= 2) {
                            if (dtTxt.split("/")[1].toString().split(".")[1].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[1].toString().split(".")[1];
                            else
                                nwTxt += dtTxt.split("/")[1].toString().split(".")[1];
                        }
                        if (dtTxt.split("/")[1].toString().split("-").length >= 2) {
                            if (dtTxt.split("/")[1].toString().split("-")[0].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[1].toString().split("-")[0];
                            else
                                nwTxt += dtTxt.split("/")[1].toString().split("-")[0];
                        }
                        if (dtTxt.split("/")[1].toString().split("-").length >= 2) {
                            if (dtTxt.split("/")[1].toString().split("-")[1].length == 1)
                                nwTxt += "0" + dtTxt.split("/")[1].toString().split("-")[1];
                            else
                                nwTxt += dtTxt.split("/")[1].toString().split("-")[1];
                        }
                    }
                    if (!(dtTxt.split("/")[1].toString().indexOf("-") >= 1 || dtTxt.split("/")[1].toString().indexOf(".") >= 1 || dtTxt.split("/")[0].toString().indexOf("-") >= 1 || dtTxt.split("/")[0].toString().indexOf(".") >= 1)) {
                        if (dtTxt.split("/")[0].length == 1)
                            nwTxt += "0" + dtTxt.split("/")[0];
                        else
                            nwTxt += dtTxt.split("/")[0];
                        if (dtTxt.split("/")[1].length == 1)
                            nwTxt += "0" + dtTxt.split("/")[1];
                        else
                            nwTxt += dtTxt.split("/")[1];
                    }
                } else {
                    if (dtTxt.split("-").length >= 2) {
                        if (!(dtTxt.split("-")[1].toString().indexOf("/") >= 1 || dtTxt.split("-")[1].toString().indexOf(".") >= 1 || dtTxt.split("-")[0].toString().indexOf("/") >= 1 || dtTxt.split("-")[0].toString().indexOf(".") >= 1)) {
                            if (dtTxt.split("-")[0].length == 1)
                                nwTxt += "0" + dtTxt.split("-")[0];
                            else
                                nwTxt += dtTxt.split("-")[0];
                            if (dtTxt.split("-")[1].length == 1)
                                nwTxt += "0" + dtTxt.split("-")[1];
                            else
                                nwTxt += dtTxt.split("-")[1];
                        }
                    }
                }
            }
        }
        if (nwTxt != '')
            dtTxt = nwTxt;
        //------------------------------------
        for (i = 0; i <= dtTxt.length; i++) {
            if (dtTxt.substring(i, i + 1) == "." || dtTxt.substring(i, i + 1) == "-" || dtTxt.substring(i, i + 1) == "/") {
                sCount += 1;
            }
        }
        if (sCount > 0) {
            for (i = 0; i <= sCount - 1; i++) {
                dtTxt = dtTxt.replace('.', '');
                dtTxt = dtTxt.replace('-', '');
                dtTxt = dtTxt.replace('/', '');
            }
        }
        if (!isValidDate(dtCont, dtTxt, format, min, max)) {
            dtCont.select();
            dtCont.focus;
        }
    }
}
//For Check Valid Character On TextBox Key Press Event//---------------------------------------------
function ChkText(obj) {
    var kCode = event.keyCode
    if ((kCode >= 48 && kCode <= 57) || (kCode == 8 || kCode == 127) || (kCode == 46 || kCode == 45 || kCode == 47)) {
        if (obj.value.length >= 8) {
            var sCount = 0;
            for (i = 0; i <= obj.value.length; i++) {
                if (obj.value.substring(i, i + 1) == "." || obj.value.substring(i, i + 1) == "-" || obj.value.substring(i, i + 1) == "/") {
                    sCount += 1;
                }
            }
            if (sCount == 0) {
                return false;
            }
        }
        if (kCode == 46 || kCode == 45 || kCode == 47) {
            if (obj.value.length > 0) {
                if (obj.value.indexOf(".") > 0 || obj.value.indexOf("-") > 0 || obj.value.indexOf("/") > 0) {
                    var dLChk, mLChk, sLChk;
                    var dRChk, mRChk, sRChk;
                    dLChk = obj.value.charAt(obj.value.length - 1);
                    mLChk = obj.value.charAt(obj.value.length - 1);
                    sLChk = obj.value.charAt(obj.value.length - 1);
                    dRChk = obj.value.charAt(obj.value.length);
                    mRChk = obj.value.charAt(obj.value.length);
                    sRChk = obj.value.charAt(obj.value.length);
                    if (dLChk != '.' && mLChk != '-' && sLChk != '/' && dRChk != '.' && mRChk != '-' && sRChk != '/') {
                        var dStr, mStr, cStr;
                        var sCount = 0;
                        for (i = 0; i <= obj.value.length; i++) {
                            if (obj.value.charAt(i) == "." || obj.value.charAt(i) == "-" || obj.value.charAt(i) == "/") {
                                sCount += 1;
                                if (sCount >= 2) {
                                    return false;
                                }
                            }
                        }
                    } else {
                        return false;
                    }
                }
            } else
                return false;
        }
        return true;
    } else
        return false;
}
//End DatePicker--------------------------------------------------------------------------------------------------------------------------------------------------
function IsDecimal(e, obj) {
    var chrCode = (e.which) ? e.which : event.keyCode
    if (e.type == 'blur' && obj.value != "") {
        var exp = obj.value;
        var r = new RegExp("[0-9/]");
        if (obj.value.match(",") == ",") {
            obj.value = obj.value.replace(",", '');
        }
        if (exp.match(r) == null) {
            obj.value = ""
            return false;
        }
    }
    if (chrCode == 46) { // Check dot
        if (obj.value.indexOf(".") > 0) {
            return false;
        }
    }
    return (chrCode > 47 && chrCode < 58) ||
	         chrCode == 8 ||
	         chrCode == 46 ? true : false;
}
function IsInteger(e, Obj) {
    var chrCode = (e.which) ? e.which : event.keyCode
    return (chrCode > 47 && chrCode < 58) ||
	         chrCode == 8 ? true : false;
}
function Round(obj, RoundOf) {
    if (window.event.type == 'blur' && obj.value != "") {
        var exp = obj.value;
        var r = new RegExp("[0-9/]");
        if (obj.value.match(",") == ",") {
            obj.value = obj.value.replace(",", '');
        }
        if (exp.match(r) == null) {
            obj.value = ""
            return false;
        }
    }
    var profits = obj.value;
    if (RoundOf != undefined) {
        obj.value = Number(profits).toFixed(Number(RoundOf));
    }
    else {
        obj.value = Number(profits).toFixed(2);
    }
}
function RoundInt(obj) {
    var profits = obj.value;
    if (profits != "") {
        obj.value = Number(profits);
    }
}
function checkValidEmail(EmailId) {
    var ValEmail = EmailId.value;
    if (ValEmail.trim() != '') {
        var EmailExp = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        if (!EmailExp.test(ValEmail)) {
            var val = confirm('Please Enter Valid Email ?\n Do You Want To Clear Text !!');
            if (val) {
                EmailId.value = '';
                EmailId.focus();
            }
            else {
                EmailId.focus();
            }
        }
    }
}
function CheckValidDate(dtControl) {
    var dateStr = dtControl.value;
    if (dateStr.trim() == "") {
        return true;
    }
    var slash1 = dateStr.indexOf("/");
    if (slash1 == -1) {
        slash1 = dateStr.indexOf("-");
    }
    // if no slashes or dashes, invalid date
    if (slash1 == -1) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    var dateDay = dateStr.substring(0, slash1)
    var dateMonthAndYear = dateStr.substring(slash1 + 1, dateStr.length);
    var slash2 = dateMonthAndYear.indexOf("/");
    if (slash2 == -1) { slash2 = dateMonthAndYear.indexOf("-"); }
    // if not a second slash or dash, invalid date
    if (slash2 == -1) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    var dateMonth = dateMonthAndYear.substring(0, slash2);
    var dateYear = dateMonthAndYear.substring(slash2 + 1, dateMonthAndYear.length);
    if ((dateMonth == "") || (dateDay == "") || (dateYear == "")) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    // if any non-digits in the month, invalid date
    for (var x = 0; x < dateMonth.length; x++) {
        var digit = dateMonth.substring(x, x + 1);
        if ((digit < "0") || (digit > "9")) {
            alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
            dtControl.value = "";
            dtControl.focus();
            return false;
        }
    }
    // convert the text month to a number
    var numMonth = 0;
    for (var x = 0; x < dateMonth.length; x++) {
        digit = dateMonth.substring(x, x + 1);
        numMonth *= 10;
        numMonth += parseInt(digit);
    }
    if ((numMonth <= 0) || (numMonth > 12)) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    // if any non-digits in the day, invalid date
    for (var x = 0; x < dateDay.length; x++) {
        digit = dateDay.substring(x, x + 1);
        if ((digit < "0") || (digit > "9")) {
            alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
            dtControl.value = "";
            dtControl.focus();
            return false;
        }
    }
    // convert the text day to a number
    var numDay = 0;
    for (var x = 0; x < dateDay.length; x++) {
        digit = dateDay.substring(x, x + 1);
        numDay *= 10;
        numDay += parseInt(digit);
    }
    if ((numDay <= 0) || (numDay > 31)) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    // February can't be greater than 29 (leap year calculation comes later)
    if ((numMonth == 2) && (numDay > 29)) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    // check for months with only 30 days
    if ((numMonth == 4) || (numMonth == 6) || (numMonth == 9) || (numMonth == 11)) {
        if (numDay > 30) {
            alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
            dtControl.value = "";
            dtControl.focus();
            return false;
        }
    }
    // if any non-digits in the year, invalid date
    for (var x = 0; x < dateYear.length; x++) {
        digit = dateYear.substring(x, x + 1);
        if ((digit < "0") || (digit > "9")) {
            alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
            dtControl.value = "";
            dtControl.focus();
            return false;
        }
    }
    // convert the text year to a number
    var numYear = 0;
    for (var x = 0; x < dateYear.length; x++) {
        digit = dateYear.substring(x, x + 1);
        numYear *= 10;
        numYear += parseInt(digit);
    }
    // Year must be a 2-digit year or a 4-digit year
    if ((dateYear.length != 2) && (dateYear.length != 4)) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    // if 2-digit year, use 50 as a pivot date
    if ((numYear < 50) && (dateYear.length == 2)) { numYear += 2000; }
    if ((numYear < 100) && (dateYear.length == 2)) { numYear += 1900; }
    if ((numYear <= 0) || (numYear > 9999)) {
        alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
        dtControl.value = "";
        dtControl.focus();
        return false;
    }
    // check for leap year if the month and day is Feb 29
    if ((numMonth == 2) && (numDay == 29)) {
        var div4 = numYear % 4;
        var div100 = numYear % 100;
        var div400 = numYear % 400;
        // if not divisible by 4, then not a leap year so Feb 29 is invalid
        if (div4 != 0) {
            alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
            dtControl.value = "";
            dtControl.focus();
            return false;
        }
        // at this point, year is divisible by 4. So if year is divisible by
        // 100 and not 400, then it's not a leap year so Feb 29 is invalid
        if ((div100 == 0) && (div400 != 0)) {
            alert("Please Enter Valid Date!! \n \n  Date Format Should Be [dd/MM/yyyy] !!");
            dtControl.value = "";
            dtControl.focus();
            return false;
        }
    }
    // date is valid
    return true;
}
function CompareFromCurrentDate(Date1, mMsgDate) {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm }
    var today = dd + '/' + mm + '/' + yyyy;
    if (checkDateNumber(Date1.value)) {
        if (!CheckValidDate(Date1)) {
            Date1.value = '';
            Date1.focus();
            return false;
        }
    }
    if (checkDateNumber(Date1.value) && checkDateNumber(today)) {
        if (!cmpDate(Date1.value, today)) {
            alert(mMsgDate + ' should be less than or equal to Current Date !!.');
            Date1.value = '';
            Date1.focus();
            return false;
        }
    }
    return true;
}
function CompareDate(Date1, Date2, mMsgDate1, MsgDate2) {
    Date1 = document.getElementById(Date1);
    Date2 = document.getElementById(Date2);
    if (checkDateNumber(Date1.value)) {
        if (!CheckValidDate(Date1)) {
            Date1.value = '';
            Date1.focus();
            return false;
        }
    }
    if (checkDateNumber(Date2.value)) {
        if (!CheckValidDate(Date2)) {
            Date2.value = '';
            Date2.focus();
            return false;
        }
    }
    if (checkDateNumber(Date1.value) && checkDateNumber(Date2.value)) {
        if (!cmpDate(Date1.value, Date2.value)) {
            alert(mMsgDate1 + ' should be less than or equal to ' + MsgDate2);
            Date1.value = '';
            Date1.focus();
            return false;
        }
    }
    return true;
}
function CompareDateWithEqual(Date1, Date2, mMsgDate1, MsgDate2) {
    Date1 = document.getElementById(Date1);
    Date2 = document.getElementById(Date2);
    if (checkDateNumber(Date1.value)) {
        if (!CheckValidDate(Date1)) {
            Date1.value = '';
            Date1.focus();
            return false;
        }
    }
    if (Date2 != null) {
        if (checkDateNumber(Date2.value)) {
            if (!CheckValidDate(Date2)) {
                Date2.value = '';
                Date2.focus();
                return false;
            }
        }
        if (checkDateNumber(Date1.value) && checkDateNumber(Date2.value)) {
            if (!ComDateWithEqual(Date1.value, Date2.value)) {
                alert(mMsgDate1 + ' should be less than or equal to ' + MsgDate2);
                Date1.value = '';
                Date1.focus();
                return false;
            }
        }
    }
    return true;
}
function OpenPopUpWindow(page, id1, id2, id3, id4, id5, id6) {
    if (id1 == null) id1 = "";
    if (id2 == null) id2 = "";
    if (id3 == null) id3 = "";
    if (id4 == null) id4 = "";
    if (id5 == null) id5 = "";
    if (id6 == null) id6 = "";
    var urlname;
    var width;
    var height;
    urlname = page + ".aspx?openfrom=popup&id1=" + id1 + "&id2=" + id2 + "&id3=" + id3 + "&id4=" + id4 + "&id5=" + id5 + "&id6=" + id6;
    width = 1200;
    height = 600;
    return PopUP(urlname, width, height);
}
function GetLeapYearDate(year, month) {
    var leapYear;
    var daysInMonth;
    var Dates;
    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) leapYear = 'Yes'; else leapYear = 'No';
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        daysInMonth = 31;
    else if (month == 4 || month == 6 || month == 9 || month == 11)
        daysInMonth = 30;
    if (month == 2 && leapYear == 'Yes') daysInMonth = 29; else daysInMonth = 28;
    Dates = daysInMonth + '/' + month + '/' + year;
    return Dates;
}
var CLIPBOARD = "";
function ShowRightClickMenu(GVReport, MainMenus, SubMenus) {
    if (GVReport != null) {
        var RInput = GVReport.getElementsByTagName('div');
        for (var i = 0; i < RInput.length; i++) {
            var MnMenu = MainMenus.split("|");
            var SbMenu = SubMenus.split("|");
            for (var k = 0; k <= MnMenu.length - 1; k++) {
                var MainMenu = MnMenu[k];
                var SubMenu = SbMenu[k];
                if (RInput[i].id.toString().toLowerCase().indexOf(MainMenu.toLowerCase()) > 0) {
                    var ULId = RInput[i].id.split("_")[RInput[i].id.split("_").length - 2];
                    ULId = RInput[i].id.replace(ULId, SubMenu);
                    ULId = document.getElementById(ULId);
                    if (ULId != null) {
                        $("#" + RInput[i].id + "").contextmenu({
                            delegate: ".hasmenu2",
                            hide: { effect: "explode", duration: "slow" },
                            menu: "#" + ULId.id + "",
                            position: { my: "left top", at: "left bottom" },
                            position: function (event, ui) {
                                position: "absolute";
                                return { my: "left top", at: "left bottom", of: ui.target };
                            },
                            preventSelect: true,
                            show: { effect: "fold", duration: "slow" },
                            taphold: true,
                            uiMenuOptions: { // Additional options, used when UI Menu is created
                                position: { my: "left+1 top", at: "right top+22" }
                            },
                            focus: function (event, ui) {
                                var menuId = ui.item.find(">a").attr("href");
                                $("#info").text("focus " + menuId);
                                //MenuSubContent
                                console.log("focus", ui.item);
                            },
                            blur: function (event, ui) {
                                $("#info").text("");
                                console.log("blur", ui.item);
                            },
                            beforeOpen: function (event, ui) {
                                //			$("#container").contextmenu("replaceMenu", "#options2");
                                //			$("#container").contextmenu("replaceMenu", [{title: "aaa"}, {title: "bbb"}]);
                            },
                            open: function (event, ui) {
                                //          alert("open on " + ui.target.text());
                            },
                            select: function (event, ui) {
                            }
                        });
                    }
                }
            }
        }
    }
}
function GetDate() {
    var d = new Date();
    var month = d.getMonth() + 1; var day = d.getDate();
    var CurrentDate = (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + d.getFullYear();
    return CurrentDate;
}


function GetValidatefrmDB(HdnfldId, _ModuleName, _SpName, _A, _B, _C, _D) {
    HdnfldId = document.getElementById(HdnfldId);
    _ModuleName = (_ModuleName == null) ? "" : _ModuleName;
    _SpName = (_SpName == null) ? "" : _SpName;
    _A = (_A == null) ? "" : _A;
    _B = (_B == null) ? "" : _B;
    _C = (_C == null) ? "" : _C;
    _D = (_D == null) ? "" : _D;
    HdnfldId.value = '';
    var url = '/Service/GetValidatefromDB.asmx/GetValidate';
    var param = "'_ModuleName' :'" + _ModuleName + "','_SpName' :'" + _SpName + "','_A' :'" + _A + "','_B' :'" + _B + "','_C' :'" + _C + "','_D':'" + _D + "'";
    $.ajax({
        type: 'post',
        url: url,
        data: "{" + param + "}",
        async: false,
            contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: 'json',
        success: function (response) {
            if (response.d == '#Error') {
                alert('Exception occured while fetching record..!!');
                HdnfldId.value = "#Error";
                return false;
            }
            else {
                if (response.d != '') {
                    if (response.d.toString().indexOf('|') > -1) {
                        if (response.d.toString().split('|').length == 2) {
                            alert(response.d.toString().split('|')[0] + '\n' + response.d.toString().split('|')[1]);
                        }
                        else if (response.d.toString().split('|').length == 3) {
                            alert(response.d.toString().split('|')[0] + '\n' + response.d.toString().split('|')[1] + '\n' + response.d.toString().split('|')[2]);
                        }
                        else if (response.d.toString().split('|').length == 4) {
                            alert(response.d.toString().split('|')[0] + '\n' + response.d.toString().split('|')[1] + '\n' + response.d.toString().split('|')[2] + '\n' + response.d.toString().split('|')[3]);
                        }
                        else {
                            alert(response.d);
                        }
                    }
                    else {
                        alert(response.d);
                        HdnfldId.value = "#Error";
                    }
                }
            }
        },
        error: function (e) {
            alert('Exception occured while cheching record..!!');
            HdnfldId.value = "#Error";
            return false;
        }
    });
}