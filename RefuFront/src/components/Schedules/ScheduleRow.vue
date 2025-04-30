<script setup lang="ts">
import SignUpButton from './SignUpButton.vue'

defineProps({
  day: String,
  StartTime: String,
  
  volunteers: {
    type: Array,
    default: () => [],
  },
})
</script>

<template>
  <tr>
    <td>{{ day }}</td>
    <td>{{ StartTime || '-' }}</td>
    <td>
      <span v-if="volunteers.length">{{ volunteers.length }} voluntarios</span>
      <span v-else>Nadie apuntado</span>
    </td>
    <td>
      <SignUpButton />
    </td>
  </tr>
</template>
