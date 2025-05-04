// stores/weekNavigatorStore.ts
import { defineStore } from 'pinia'

function startOfWeek(date: Date): Date {
  const day = date.getDay()
  const diff = day === 0 ? -6 : 1 - day
  const monday = new Date(date)
  monday.setDate(date.getDate() + diff)
  monday.setHours(0, 0, 0, 0)
  return monday
}

export const useWeekNavigatorStore = defineStore('weekNavigator', {
  state: () => ({
    offset: 0,
  }),
  getters: {
    weekDates: (state) => {
      const today = new Date()
      const start = startOfWeek(today)
      start.setDate(start.getDate() + state.offset * 7)

      const dates: Date[] = []
      for (let i = 0; i < 7; i++) {
        const d = new Date(start)
        d.setDate(start.getDate() + i)
        dates.push(d)
      }
      return dates
    }
  },
  actions: {
    nextWeek() {
      this.offset++
    },
    previousWeek() {
      this.offset--
    }
  }
})
