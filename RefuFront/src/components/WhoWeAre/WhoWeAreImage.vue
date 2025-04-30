    <script setup lang="ts">
    defineProps<{
      backgroundImage?: string
    }>()
    </script>
    
<template>
    <v-img
      :src="backgroundImage"
      class="who-img"
      aspect-ratio="1/1"
      cover
      rounded="xl"
    />
</template>


<style scoped>
.responsive-img-wrapper {
  width: 100%;
  max-width: 600px;
}

.who-img {
  width: 100%;
  max-width: 600px;
  height: auto;
  object-fit: cover;
}

@media (max-width: 960px) {
  .who-img {
    max-height: 240px;
    max-width: 240px;
  }
}
</style>
