<script setup lang="ts">
import { useScheduleStore } from '@/stores/scheduleStore';
import ScheduleRow from '@/components/Schedules/ScheduleRow.vue';
import { onMounted } from 'vue';


const store = useScheduleStore()

const slots = new Array<number>()

slots.push(1)

onMounted(() =>{
    console.log("montando");
    
    store.fetchAll();
})

</script>

<template>
    <div>
      <table>
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
            v-for="(schedule, i) in store.schedules"
            :key="i"
            :day="schedule.day"
          />
        </tbody>
      </table>
    </div>
  </template>
  