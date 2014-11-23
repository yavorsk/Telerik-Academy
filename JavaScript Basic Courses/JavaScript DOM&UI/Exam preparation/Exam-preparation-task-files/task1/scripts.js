function createCalendar(selector, events) {
    var container = document.querySelector(selector);

    //var dayBox = document.createElement('div');
    //var dayTitle = document.createElement('strong');
    //var dayEvents = document.createElement('div');

    var dFrag = document.createDocumentFragment();

    var dayCounter = 1;
    var date;

    for (date = 1; date <= 30; date++) {
        var day = getDate(dayCounter);

        var dayBox = document.createElement('div');
        dayBox.style.width = '140px';
        dayBox.style.height = '120px';
        dayBox.style.borderStyle = 'solid';
        dayBox.style.borderColor = 'black';
        dayBox.style.borderWidth = '1px';
        dayBox.style.cssFloat = 'left';
        if (dayCounter == 1) {
            dayBox.style.clear = 'left';
        }

        var dayTitle = document.createElement('strong');
        dayTitle.innerHTML = day + ' ' + date + ' June 2014';
        dayTitle.style.display = 'block';
        dayTitle.style.backgroundColor = 'lightGray';
        dayTitle.style.borderBottomColor = 'black';
        dayTitle.style.borderBottomWidth = '1px';
        dayTitle.style.borderBottomStyle = 'solid';
        dayTitle.style.textAlign = 'center';

        var dayEvents = document.createElement('div');

        for (var i = 0; i < events.length; i++) {
            if (events[i].date == date) {
                dayEvents.innerHTML = events[i].hour + ' ' + events[i].title;
            }
        }

        dayBox.appendChild(dayTitle);
        dayBox.appendChild(dayEvents);

        dFrag.appendChild(dayBox);

        dayCounter++;
        if (dayCounter == 8) {
            dayCounter = 1;
        }
    }

    container.appendChild(dFrag);

    var turnGray = function (ev) {
        this.firstChild.style.backgroundColor = 'gray';
    }

    var turnLightGray = function (ev) {
        this.firstChild.style.backgroundColor = 'lightGray';
    }

    var calendarCells = document.querySelectorAll('#calendar-container > div');
    console.log(calendarCells);
    for (var i = 0; i < calendarCells.length; i++) {
        calendarCells[i].addEventListener('mouseover', turnGray, false);

        calendarCells[i].addEventListener('mouseout', turnLightGray, false);

        calendarCells[i].addEventListener('click', function () {
            var oldSelected = document.querySelector('.selected');
            if (oldSelected) {
                oldSelected.className = '';
                oldSelected.firstChild.style.backgroundColor = 'lightGray';

                oldSelected.addEventListener('mouseover', turnGray, false);
                oldSelected.addEventListener('mouseout', turnLightGray, false);

            }
            this.className = 'selected';
            this.firstChild.style.backgroundColor = 'white';
            this.removeEventListener('mouseover', turnGray, false);
            this.removeEventListener('mouseout', turnLightGray, false);
        })
    }





    function getDate(counter) {
        var result ='';

        switch (counter) {
            case 1: result = 'Sun'; break;
            case 2: result = 'Mon'; break;
            case 3: result = 'Tue'; break;
            case 4: result = 'Wed'; break;
            case 5: result = 'Thu'; break;
            case 6: result = 'Fri'; break;
            case 7: result = 'Sat'; break;
        }

        return result;
    }
}