<script setup lang="ts">
defineProps<{
  backgroundImage?: string
}>()
</script>

<template>
  <div class="hero-banner">
    <v-img class="hero-media" :src="backgroundImage" cover />
    <div class="hero-content">
      <slot />
    </div>
  </div>
</template>

<style scoped>
.hero-banner {
  position: relative;
  width: 100%;
  height: 90vh;
  min-height: 600px;
  overflow: hidden;
}

.hero-media {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.hero-content {
  position: absolute;
  top: 50%;
  left: 10%;
  transform: translateY(-50%);
  z-index: 2;
  max-width: 500px;
  width: calc(100% - 4rem);
  padding: 1.5rem;
}

@media (max-width: 450px) {
  .hero-content {
    top: 40%;
    text-align: center;
    width: 85%;
    font-size: 12px;
    padding: 1.25rem;
  }
}

</style>
