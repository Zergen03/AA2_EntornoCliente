<script setup lang="ts">
import ZoneSelector from '@/components/Schedules/ZoneSelector.vue'
import { onMounted } from 'vue'
import { useScheduleStore } from '@/stores/scheduleStore'
import { useZoneStore } from '@/stores/zoneStore'

const userStore = useScheduleStore()
const zoneStore = useZoneStore()

onMounted(() => {
  if (userStore.schedules.length === 0) {
    userStore.fetchAll()
  }

  if (zoneStore.zones.length === 0) {
    zoneStore.fetchAll()
  }
})
</script>

<template>
  <ZoneSelector></ZoneSelector>
</template>
