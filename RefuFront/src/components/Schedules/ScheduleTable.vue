<script setup lang="ts">
import { useScheduleStore } from '@/stores/scheduleStore'
import ScheduleRow from '@/components/Schedules/ScheduleRow.vue'
import ScheduleCard from '@/components/Schedules/ScheduleCard.vue'
import { watch } from 'vue'
import { computed } from 'vue'
import { useWeekNavigatorStore } from '@/stores/WeekNavigation'
import { storeToRefs } from 'pinia'
import { jwtDecode } from 'jwt-decode'

const store = useScheduleStore()
const weekStore = useWeekNavigatorStore()
const { weekDates } = storeToRefs(weekStore)
const { nextWeek, previousWeek } = weekStore

const props = defineProps<{
  zoneId: number
  zoneName: string
}>()

const groupedSchedules = computed(() => {
  const schedulesByDay: Record<string, any> = {}

  for (const item of store.schedules) {
    const isoDate = new Date(item.day).toISOString().slice(0, 10)
    if (!schedulesByDay[isoDate]) {
      schedulesByDay[isoDate] = {
        day: isoDate,
        startTime: item.startTime,
        endTime: item.endTime,
        volunteers: [],
        scheduleId: item.scheduleId,
        zoneId: item.zoneId,
        zoneName: item.zoneName,
      }
    }
    if (item.zoneId == props.zoneId) {
      const alreadyExists = schedulesByDay[isoDate].volunteers.some(
        (v: { userId: number }) => v.userId === item.userId,
      )

      if (!alreadyExists) {
        schedulesByDay[isoDate].volunteers.push({
          userId: item.userId,
          userName: item.userName,
        })
      }
    }
  }

  return weekDates.value.map((date) => {
    const isoDate = date.toISOString().slice(0, 10)
    if (schedulesByDay[isoDate]) {
      return schedulesByDay[isoDate]
    } else {
      return {
        day: isoDate,
        startTime: null,
        endTime: null,
        volunteers: [],
        scheduleId: null,
        zoneId: null,
        zoneName: null,
      }
    }
  })
})

async function updateTime(payload: { day: string; time: string; schedule: number }) {
  const token = localStorage.getItem('token');
  if (!token) return;
  
  const validTimeFormat = /^\d{2}:\d{2}$/;

  if(!payload.time || !validTimeFormat.test(payload.time)) return;

  const decoded: any = jwtDecode(token);
  const name = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];

  const scheduleResponse: any = await store.addSchedule(
    payload.day,
    payload.time,
    props.zoneId,
    decoded.userId
  );

  store.schedules.push({
    day: payload.day,
    startTime: payload.time,
    endTime: scheduleResponse.endTime,
    scheduleId: scheduleResponse.id,
    zoneId: props.zoneId,
    zoneName: props.zoneName,
    userId: decoded.userId,
    userName: name,
  });

  console.log("Horario actualizado correctamente");
}


watch(
  () => weekDates.value,
  (newWeek) => {
    console.log('Fechas semana cambiadas:', newWeek)
  },
)
</script>

<template>
  <div>
    <!-- Desktop -->
    <table class="w-100 d-none d-md-table">
      <thead>
        <tr>
          <th>Día</th>
          <th>Horario</th>
          <th>Voluntarios</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <ScheduleRow
          v-for="(schedule, i) in groupedSchedules"
          :key="schedule.day"
          :day="schedule.day"
          :startTime="schedule.startTime"
          :endTime="schedule.endTime"
          :volunteers="schedule.volunteers"
          :scheduleId="schedule.scheduleId"
          @updateTime="updateTime"
        />
      </tbody>
    </table>

    <!-- Mobile -->
    <div class="d-md-none">
      <ScheduleCard
        v-for="(schedule, i) in groupedSchedules"
        :key="i"
        :day="schedule.day"
        :startTime="schedule.startTime"
        :volunteers="schedule.volunteers"
      />
    </div>
  </div>
</template>

<style scoped>
.table-container {
  overflow-x: auto;
  max-width: 100%;
}
</style>
