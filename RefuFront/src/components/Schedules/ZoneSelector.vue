<script setup lang="ts">
import { ref } from 'vue'
import ScheduleTable from './ScheduleTable.vue'

const expanded = ref(0) // index del panel abierto

const zones = [
  { name: 'Bienvenida + Adaptación', dataKey: 'adaptacion' },
  { name: 'Guardería', dataKey: 'guarderia' },
]
</script>

<template>
  <v-expansion-panels v-model="expanded" multiple>
    <v-expansion-panel
      v-for="(zone, index) in zones"
      :key="zone.name"
      class="zone-panel"
    >
      <v-expansion-panel-title>
        <span class="zone-title">{{ zone.name }}</span>
      </v-expansion-panel-title>

      <v-expansion-panel-text>
        <ScheduleTable :zone="zone.dataKey" />
      </v-expansion-panel-text>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<style scoped>
.zone-panel {
  margin-bottom: 16px; /* separación entre paneles */
  border-radius: 8px;
  overflow: hidden;
  border: 1px solid #ffffff33;
}

.zone-title {
  font-family: 'Poetsen One', sans-serif;
  font-size: 1.2rem;
  color: orange;
}
</style>
