import type { schedule } from '@/assets/core/schedule'
import { defineStore } from 'pinia'
import { reactive } from 'vue'

export const useScheduleStore = defineStore('schedules', () => {
  const schedules = reactive(new Array<schedule>())
  function fetchAll() {
    fetch('http://localhost:6927/api/ScheduleAssignments')
      .then((res) => res.json())
      .then((data) => {
        const scheduleInfo: schedule[] = data.map((d: schedule) => ({
          userId: d.userId,
          userName: d.userName,
          zoneId: d.zoneId,
          zoneName: d.zoneName,
          scheduleId: d.scheduleId,
          day: d.day,
          startTime: d.startTime,
          endTime: d.endTime,
        }))
        schedules.slice(0, schedules.length)
        schedules.push(...scheduleInfo)
        console.log(schedules)
      })
  }

  function addSchedule(day: string, time: string, zone: number, user: number): Promise<any> {
    return fetch('http://localhost:6927/api/Schedule', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        zoneId: zone,
        day: day,
        startTime: time,
      }),
    })
      .then((res) => res.json())
      .then((data: any) => {
        console.log('schedule added: ' + JSON.stringify(data))
        addScheduleAssignment(user, data.id)
        return data
      })
      .catch((err) => console.error(err))
  }

  function addScheduleAssignment(user: number, schedule: number) {
    console.log(`SA user: ${user}\n SA schedule: ${schedule}`);
    
    fetch('http://localhost:6927/api/ScheduleAssignments', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        userId: user,
        scheduleId: schedule,
      }),
    })
      .then((res) => res.json())
      .then((data: any) => {
        console.log('scheduleAssignment added: ' + data)
      })
      .catch((err) => console.error(err))
  }

  return { schedules, fetchAll, addSchedule }
})
