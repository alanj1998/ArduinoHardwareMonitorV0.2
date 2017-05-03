function ProcessData() {
    var response = getFile();
    data = response.split(','); 
}  
            
function getFile() {
                var requestFile = new XMLHttpRequest();  
                var string;
                requestFile.open("GET", "http://localhost/pcData.txt", false);
                requestFile.send();
                if (requestFile.status === 200) {      
                    return requestFile.responseText;
                }                   
            }    
            
function DataAssigning() {
     ProcessData();
                
     if (String(data[1]) == "DIS") {
         //Set Temperature
         //CHANGE THE SET ATTRIBUTES TO SET + GET! LOOK AT RESIZE JS TO KNOW WHATS UPP!
         document.getElementById('cpuTemp').setAttribute("value", "4.8");
         document.getElementById('cpuTempLbl').textContent = "";
         
         //Set CPU Load
         document.getElementById('cpuLoad').setAttribute("style", "transform: rotate(0deg)");
         document.getElementById('cpuLoadLbl').textContent = "";
         
         //Set RAM Load
         document.getElementById('ramLoad').setAttribute("style", "transform: rotate(0deg)");
         document.getElementById('ramLoadLbl').textContent = "";
         
         //Set HDD Load
         document.getElementById('hddLeftLbl').textContent = "";
         document.getElementById('hddLeft').setAttribute("style", "transform: rotate(0deg)");
         
         //Set CPU Name
         document.getElementById('cpuName').textContent = "";
         
         //Set RAM Name
         document.getElementById('ramName').textContent = "";
         
         //Set Image Opacity
         document.getElementById('fire').setAttribute("style", "opacity:" + 1 + ";");
         
         document.getElementById("disconnectModalBox").setAttribute("style", "display:block;");
         document.getElementById("inner").setAttribute("style", "display:block;");
     }
     else {
         document.getElementById("disconnectModalBox").setAttribute("style", "display:none;");
         document.getElementById("inner").setAttribute("style", "display:none;");
         var i;
         //Set Temperature
         var temp;
         if (data[0] < 4.8) {
             temp = 4.8;
         }
         else {
             temp = data[0];
         }
         document.getElementById('cpuTemp').setAttribute("value", temp);
         document.getElementById('cpuTempLbl').textContent = data[0]  + String.fromCharCode(176) +"C";
         
         //Set CPU Load
         var cpuDeg =  ConvertValuesToDegrees(1);
         document.getElementById('cpuLoad').setAttribute("style", "transform: rotate(" + cpuDeg + "deg);");
         document.getElementById('cpuLoadLbl').textContent = data[1] + "% CPU Load";
         
         //Set RAM Load
         var ramDeg =  ConvertValuesToDegrees(2);
         document.getElementById('ramLoad').setAttribute("style", "transform: rotate(" + ramDeg + "deg);");
         document.getElementById('ramLoadLbl').textContent = data[2] + "% RAM Load";
         
         //Set HDD Load
         document.getElementById('hddLeftLbl').textContent = data[3] + "% HDD Left";
         document.getElementById('hddLeft').setAttribute("style", "transform: rotate(" + (-90 + (data[3] * 0.9)) + "deg);");
         
         //Set CPU Name
         document.getElementById('cpuName').textContent = data[4];
         
         //Set RAM Name
         document.getElementById('ramName').textContent = data[5];
         
         //Set Image Opacity
         var opacity = GetCpuDangerLevel(data[0]);
         
         document.getElementById('fire').setAttribute("style", "opacity:" + opacity + ";");
    }
}
            
function GetTime() {
    document.getElementById('time').textContent = Date();
}

function ConvertValuesToDegrees(i) {
    var result;
    if (data[i] < 50) {
         result = (data[i] - 50) * (238/100);
    }
    else {
        result = (data[i] - 50) * (238/100);
    }
    
    return result;
}

function GetCpuDangerLevel(temperature) {
    if (temperature == 0) {
        return 0;
    }
    else if (temperature < 20) {
        return 0.1;
    }
    else if (temperature < 40) {
        return 0.2;
    }
    else if (temperature < 50) {
        return 0.4;
    }
    else if (temperature < 60) {
        return 0.5;
    }
    else if (temperature < 70) {
        return 0.7;
    }
    else if (temperature < 80) {
        return 0.8;
    }
    else {
        return 1;
    }
}