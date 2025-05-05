<script setup lang="ts">
import { jwtDecode } from 'jwt-decode'
import { useUserStore } from '@/stores/userStore'

const userStore = useUserStore()



</script>

<template>
  <v-btn @click="console.log(userStore.token)" class="btn-apuntarse">Apuntarse</v-btn>
</template>

<style scoped>
.btn-apuntarse {
  background-color: #f4a300;
  color: white;
  border: none;
  font-weight: bold;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s ease;
}

.btn-apuntarse:hover {
  transform: scale(1.05);
  cursor: pointer;
}
</style>
