<script setup lang="ts">
const props = defineProps<{
  btnColor?: string
  backgroundImage?: string
  route?: string
}>()

const color = props.btnColor ?? 'primary'
</script>

<template>
  <div class="card">
    <v-img :width="300" aspect-ratio="16/9" cover :src="backgroundImage"></v-img>
    <v-btn class="w-100" :base-color="color" rounded="0" :to="route">Únete</v-btn>
  </div>
</template>

<style scoped>
.card {
  width: 300px;
  max-width: 300px;
}
</style>
