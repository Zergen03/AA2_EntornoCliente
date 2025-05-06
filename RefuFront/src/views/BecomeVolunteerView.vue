<script setup lang="ts">
import { useUserStore } from '@/stores/userStore'
import { jwtDecode } from 'jwt-decode'
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import type { user } from '@/assets/core/user'
import AuthForm from '@/components/Auth/AuthForm.vue'

const store = useUserStore()
const router = useRouter()

const name = ref<string>('')
const email = ref<string>('')
const password = ref<string>('')
const valid = ref(false)
const errorMessage = ref('')
async function handleRegister() {
  errorMessage.value = ''
  try {
    const newUser: user = {
      name: name.value,
      email: email.value,
      password: password.value,
      IsVeteran: false,
    }
    const token = await store.register(newUser)
    console.log('Token recived: ' + token)
    router.push('/schedule')
  } catch (err: any) {
    errorMessage.value = err.message
  }
}
</script>

<template>
  <div class="container">
    <AuthForm
      :name="name"
      :email="email"
      :password="password"
      :error-message="errorMessage"
      show-name
      @update:name="name = $event"
      @update:email="email = $event"
      @update:password="password = $event"
      :on-submit="handleRegister"
    />
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: calc(100vh - 160px);
  padding: 1rem;
  box-sizing: border-box;
}
.container > * {
  width: 100%;
  max-width: 600px;
  padding: 1rem;
}
.error-message {
  color: red;
  text-align: center;
  margin-top: 1rem;
}
</style>
