<script setup lang="ts">
import SignUpButton from './SignUpButton.vue'

interface Volunteer {
  userId: number
  userName: string
}

const props = defineProps<{
  day: string
  startTime?: string
  endTime?: string
  volunteers: Volunteer[]
}>()
</script>

<template>
  <tr>
    <td>
      {{
        new Date(day)
          .toLocaleDateString('es-ES', {
            weekday: 'long',
            day: 'numeric',
            month: 'numeric',
            year: 'numeric',
          })
          .replace(/^./, (c) => c.toUpperCase())
      }}
    </td>
    <td>
      <span>
        {{ startTime || '---' }}
      </span>
      <span v-if="endTime != '00:00' && endTime != null">
        {{ '-' + endTime }}
      </span>
    </td>
    <td>
      <v-menu v-if="volunteers.length" offset-y>
        <template #activator="{ props }">
          <v-btn v-bind="props" color="primary" variant="tonal" size="small" rounded="xl">
            {{ volunteers.length }} voluntario<span v-if="volunteers.length > 1">s</span>
          </v-btn>
        </template>

        <v-list>
          <v-list-item class="volunteer" v-for="v in volunteers" :key="v.userId">
            <v-list-item-title>{{ v.userName }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <span v-else class="text-grey">Nadie apuntado</span>
    </td>

    <td>
      <SignUpButton />
    </td>
  </tr>
</template>

<style scoped>
td {
  padding: 0.75rem 1.5rem;
  vertical-align: middle;
  text-align: center;
  border-bottom: 1px solid #e0e0e0;
  background-color: #f9f9f9;
  transition: background-color 0.3s ease;
}

td:hover {
  background-color: #f1f1f1;
}

td:last-child {
  text-align: right;
  padding-right: 5rem;
}

tr:hover td {
  background-color: #eaeaea;
}

.volunteer {
  cursor: pointer;
}

.volunteer:hover {
  background-color: #eaeaea;
}
</style>
