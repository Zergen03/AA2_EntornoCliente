<script setup lang="ts">
import ZoneSelector from '@/components/Schedules/ZoneSelector.vue';
import { onMounted } from 'vue';
import { useScheduleStore } from '@/stores/scheduleStore'

const store = useScheduleStore()


onMounted(() => {
  console.log('montando')

  store.fetchAll()
})

</script>

<template>

<ZoneSelector></ZoneSelector>

</template>