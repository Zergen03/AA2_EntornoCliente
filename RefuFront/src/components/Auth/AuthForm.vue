components/AuthForm.vue
<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink } from 'vue-router'

defineProps<{
  onSubmit: () => void
  email: string
  password: string
  errorMessage?: string
  showName?: boolean
  name?: string
}>()
defineEmits(['update:email', 'update:password', 'update:name'])

const visible = ref(false)
</script>

<template>
  <div>
    <v-img
      class="mx-auto my-6"
      max-width="400"
      src="https://gestionyproteccionfelina.org/wp-content/uploads/2024/07/gyp_logo.webp"
    ></v-img>
    <v-form @submit.prevent="onSubmit">
      <v-card class="mx-auto pa-12 pb-8" elevation="8" max-width="448" rounded="lg">
        <div v-if="showName">
          <div class="text-subtitle-1 text-medium-emphasis">Name</div>

          <v-text-field
            :model-value="name"
            density="compact"
            placeholder="Username"
            prepend-inner-icon="mdi-account-plus"
            variant="outlined"
            @update:model-value="$emit('update:name', $event)"
          ></v-text-field>
        </div>
        <div class="text-subtitle-1 text-medium-emphasis">Account</div>

        <v-text-field
          :model-value="email"
          density="compact"
          placeholder="Email address"
          prepend-inner-icon="mdi-email-outline"
          variant="outlined"
          @update:model-value="$emit('update:email', $event)"
        ></v-text-field>

        <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
          Password
        </div>

        <v-text-field
          :model-value="password"
          :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
          :type="visible ? 'text' : 'password'"
          density="compact"
          placeholder="Enter your password"
          prepend-inner-icon="mdi-lock-outline"
          variant="outlined"
          @click:append-inner="visible = !visible"
          @update:model-value="$emit('update:password', $event)"
        ></v-text-field>
        <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
        <v-btn type="submit" color="primary" size="large" class="mb-8" block> {{ showName? "Register" : "Log In" }} </v-btn>

        <v-card-text v-if="!showName" class="text-center">
          <router-link to="/becomeVolunteer">
            Hazte voluntario <v-icon icon="mdi-chevron-right"></v-icon>
          </router-link>
        </v-card-text>
      </v-card>
    </v-form>
  </div>
</template>

<style scoped>
.error-message {
  color: red;
  text-align: center;
  margin-top: 1rem;
}
</style>