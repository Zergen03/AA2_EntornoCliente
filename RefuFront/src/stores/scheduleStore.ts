import type { schedule } from '@/assets/core/schedule'
import { defineStore } from 'pinia'
import { reactive } from 'vue'

export const useScheduleStore = defineStore('schedules', () => {
  const schedules = reactive(new Array<schedule>())
  function fetchAll() {
    console.log("llamando a la api")
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
        schedules.push(...scheduleInfo)
        console.log(schedules)
      })
  }

  return { schedules, fetchAll }
})
