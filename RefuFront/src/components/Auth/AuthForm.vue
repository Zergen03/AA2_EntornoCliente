<!-- components/AuthForm.vue -->
<script setup lang="ts">
defineProps<{
  onSubmit: () => void
  email: string
  password: string
  errorMessage?: string
  showName?: boolean
  name?: string
}>()
defineEmits(['update:email', 'update:password', 'update:name'])
</script>

<template>
  <v-form @submit.prevent="onSubmit">
    <v-text-field
      v-if="showName"
      :model-value="name"
      placeholder="Nombre"
      @update:model-value="$emit('update:name', $event)"
    />
    <v-text-field
      type="email"
      :model-value="email"
      placeholder="Correo"
      @update:model-value="$emit('update:email', $event)"
    />
    <v-text-field
      type="password"
      :model-value="password"
      placeholder="Contraseña"
      @update:model-value="$emit('update:password', $event)"
    />
    <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
    <v-btn type="submit" color="primary" class="w-50 mx-auto d-block">
      Enviar
    </v-btn>
  </v-form>
</template>

<style scoped>
.error-message {
  color: red;
  text-align: center;
  margin-top: 1rem;
}
</style>
