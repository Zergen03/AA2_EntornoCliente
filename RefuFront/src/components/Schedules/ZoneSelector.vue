<script setup lang="ts">
import { onMounted, ref } from 'vue'
import ScheduleTable from './ScheduleTable.vue'
import { useWeekNavigatorStore } from '@/stores/WeekNavigation'
import { useZoneStore } from '@/stores/zoneStore'

const expanded = ref(0)
const { weekDates, nextWeek, previousWeek } = useWeekNavigatorStore()
const zoneStore = useZoneStore()
const zones = zoneStore.zones

</script>

<template>
  <v-expansion-panels v-model="expanded" multiple>
    <div class="buttons">
      <v-btn color="primary" variant="tonal" rounded="xl" @click="previousWeek()"
        >Semana anterior</v-btn
      >
      <v-btn color="primary" variant="tonal" rounded="xl" @click="nextWeek()"
        >Siguiente semana</v-btn
      >
    </div>
    <v-expansion-panel v-for="(zone, index) in zones" :key="zone.name" class="zone-panel">
      <v-expansion-panel-title>
        <span class="zone-title">{{ zone.name }}</span>
      </v-expansion-panel-title>

      <v-expansion-panel-text>
        <ScheduleTable :zoneId="zone.id" :zoneName="zone.name" />
      </v-expansion-panel-text>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<style scoped>
.buttons {
  display: flex;
  gap: 5rem;
}

.zone-panel {
  margin-bottom: 16px; /* separación entre paneles */
  border-radius: 8px;
  overflow: hidden;
  border: 1px solid #ffffff33;
  width: 10%;
}

.zone-title {
  font-family: 'Poetsen One', sans-serif;
  font-size: 1.2rem;
  color: orange;
}
</style>
