<script setup lang="ts">
import SignUpButton from './SignUpButton.vue'

interface Volunteer {
  userId: number
  userName: string
}

const props = defineProps<{
  day: string
  startTime?: string
  volunteers: Volunteer[]
}>()
</script>

<template>
  <v-card class="pa-3 my-2" elevation="1">
    <div><strong>Día:</strong> {{ new Date(day).toLocaleDateString('es-ES') }}</div>
    <div><strong>Horario:</strong> {{ startTime || "---" }}</div>
    <div>
      <strong>Voluntarios:</strong>
      <v-btn v-if="volunteers.length" color="primary" size="small" variant="tonal" class="mt-1">
        {{ volunteers.length }} voluntario<span v-if="volunteers.length > 1">s</span>
      </v-btn>
      <span v-else>Nadie apuntado</span>
    </div>
    <div class="mt-2 text-right">
      <SignUpButton />
    </div>
  </v-card>
</template>
