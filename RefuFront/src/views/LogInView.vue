<script setup lang="ts">
import { useUserStore } from '@/stores/userStore'
import { jwtDecode } from 'jwt-decode'
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import AuthForm from '@/components/Auth/AuthForm.vue'

const store = useUserStore()
const router = useRouter()

const email = ref('')
const password = ref('')
const valid = ref(false)
const errorMessage = ref('')
async function handleLogin() {
  errorMessage.value = ''
  try {
    const token = await store.login(email.value, password.value)
    console.log('Token recived: ' + token)
    router.push('/schedule')
    if (typeof token === 'string') {
      const decoded = jwtDecode<{ IsVeteran: string }>(token)
      console.log('Decoded token:', decoded)
    } else {
      throw new Error('Invalid token format')
    }
  } catch (err: any) {
    errorMessage.value = err.message
  }
}
</script>

<template>
  <div class="container">
    <AuthForm
      :email="email"
      :password="password"
      :error-message="errorMessage"
      @update:email="email = $event"
      @update:password="password = $event"
      :on-submit="handleLogin"
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
