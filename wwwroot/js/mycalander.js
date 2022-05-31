﻿////// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
////// for details on configuring this project to bundle and minify static web assets.

////// Write your JavaScript code.
////$('#my-todo-list').TodoList({
////    onCheck: function (checkbox) {
////        // Do something when the checkbox is checked
////    },
////    onUnCheck: function (checkbox) {
////        // Do something after the checkbox has been unchecked
////    }
////})

$(function () {

    /* initialize the external events 
     -----------------------------------------------------------------*/
    function ini_events(ele) {
        ele.each(function () {

            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)  
            // it doesn't need to have a start or end  
            var eventObject = {
                title: $.trim($(this).text()) // use the element's text as the event title  
            }

            // store the Event Object in the DOM element so we can get to it later  
            $(this).data('eventObject', eventObject)

            // make the event draggable using jQuery UI  
            $(this).draggable({
                zIndex: 1070,
                revert: true, // will cause the event to go back to its  
                revertDuration: 0  //  original position after the drag  
            })

        })
    }

    ini_events($('#external-events div.external-event'))

    /* initialize the calendar 
     -----------------------------------------------------------------*/
    //Date for the calendar events (dummy data)  
    var date = new Date()
    var d = date.getDate(),
        m = date.getMonth(),
        y = date.getFullYear()

    var Calendar = FullCalendar.Calendar;
    var Draggable = FullCalendarInteraction.Draggable;

    var containerEl = document.getElementById('external-events');
    var checkbox = document.getElementById('drop-remove');
    var calendarEl = document.getElementById('calendar');

    // initialize the external events  
    // -----------------------------------------------------------------  

    new Draggable(containerEl, {
        itemSelector: '.external-event',
        eventData: function (eventEl) {
            console.log(eventEl);
            return {
                title: eventEl.innerText,
                backgroundColor: window.getComputedStyle(eventEl, null).getPropertyValue('background-color'),
                borderColor: window.getComputedStyle(eventEl, null).getPropertyValue('background-color'),
                textColor: window.getComputedStyle(eventEl, null).getPropertyValue('color'),
            };
        }
    });

    GetData();

    function GenerateCalander(events) {
        var calendar = new Calendar(calendarEl, {

            //Plugins for full canlender  

            //plugins: ['bootstrap', 'interaction', 'dayGrid', 'timeGrid'],  
            //initialView: 'timeGridWeek',  

            plugins: ['bootstrap', 'interaction', 'timeGrid'],
            initialView: 'timeGridWeek',

            //select your timeZone as u wish to select  
            timeZone: 'UTC',

            //Slot duration fix to 30 minutes now .......you can chage any slot duration from here.  
            slotDuration: '00:30:00',
            slotLabelInterval: 30,
            slotMinutes: 30,
            snapDuration: '01:00:00',

            header: {
                left: 'prev,next today',
                center: 'title',
                //right: 'dayGridMonth,timeGridWeek,timeGridDay'  
                right: 'timeGridWeek'
            },

            //Random default events  
            events: events
            ,

            editable: true,
            droppable: true, // this allows things to be dropped onto the calendar !!!  
            drop: function (info) {
                // is the "remove after drop" checkbox checked?  
                if (checkbox.checked) {
                    // if so, remove the element from the "Draggable Events" list  
                    info.draggedEl.parentNode.removeChild(info.draggedEl);
                }
            },
            nextDayThreshold: "00:00:00",
            nowIndicator: true,
            eventDrop: function (data) {
                UpdateEventDetails(data.event.id, data.event.start, data.event.end);
            },
            eventResize: function (data) {
                //console.log(data.event.id)  
                //update your event here  
                UpdateEventDetails(data.event.id, data.event.start, data.event.end);
            },
            eventClick: function (calEvent, jsEvent, view) {
                //Work on click event like delete and view details  
                alert('Click Event Called')
            },
            selectHelper: true,
            select: function (start, end, jsEvent, view) {
                //called when an event is selected  
                alert('Select Event Called')
            },

        });

        calendar.render();
    }


    /* ADDING EVENTS */
    var currColor = '#3c8dbc' //Red by default  
    //Color chooser button  
    var colorChooser = $('#color-chooser-btn')
    $('#color-chooser > li > a').click(function (e) {
        e.preventDefault()
        //Save color  
        currColor = $(this).css('color')
        //Add color effect to button  
        $('#add-new-event').css({
            'background-color': currColor,
            'border-color': currColor
        })
    })
    $('#add-new-event').click(function (e) {
        e.preventDefault()
        //Get value and make sure it is not null  
        var val = $('#new-event').val()
        if (val.length == 0) {
            return
        }

        //Create events  
        var event = $('<div />')
        event.css({
            'background-color': currColor,
            'border-color': currColor,
            'color': '#fff'
        }).addClass('external-event')
        event.html(val)
        $('#external-events').prepend(event)

        //Add draggable funtionality  
        ini_events(event)

        //Remove event from text input  
        $('#new-event').val('')
    })




    function GetData() {
        var events = [];
        $.ajax({
            url: 'http://localhost:3617/admin/Calander/GetCalendarData',
            type: "GET",
            dataType: "JSON",
            success: function (result) {
                $.each(result, function (i, data) {
                    events.push(
                        {
                            title: data.Title,
                            description: data.Desc,
                            start: moment(data.Start_Date).format('YYYY-MM-DD HH:mm:ss'),
                            end: moment(data.End_Date).format('YYYY-MM-DD HH:mm:ss'),
                            backgroundColor: '#00a65a', //Success (green)  
                            borderColor: '#00a65a', //Success (green)  
                            id: data.Id,
                            allDay: false,
                        });
                });
                GenerateCalander(events);

            }
        })



    }

    function UpdateEventDetails(eventId, StartDate, EndDate) {
        debugger
        var object = new Object();
        object.Id = parseInt(eventId);
        object.Start_Date = StartDate;
        object.End_Date = EndDate;

        $.ajax({
            url: 'http://localhost:3617/admin/Calander/UpdateCalanderData',
            type: "POST",
            dataType: "JSON",
            data: object,
            success: function (result) {
                debugger;
                alert("updated successfully-Id:" + result)

            }

        });

    }


});