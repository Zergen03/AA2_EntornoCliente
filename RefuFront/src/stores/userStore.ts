import type { user } from '@/assets/core/user'
import { defineStore } from 'pinia'
import { computed, reactive, ref } from 'vue'

export const useUserStore = defineStore('users', () => {
  const users = reactive(new Array<user>())
  let token = ref<string | null>(localStorage.getItem('token'))
  let isLoggedIn = ref(!!token.value)

  function fetchAll() {
    if (users.length == 0) {
      fetch('http://localhost:6927/api/User')
        .then((res) => res.json())
        .then((data) => {
          const usersInfo: user[] = data.map((d: user) => ({
            id: d.id,
            Name: d.name,
            Email: d.email,
            IsVeteran: d.IsVeteran,
          }))
          users.push(...usersInfo)
        })
    }
  }

  function userById(id: number) {
    return users.find((user) => user.id === id)
  }

  function register(newUser: user) {
    fetch('http://localhost:6927/api/User', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newUser),
    })
      .then((res) => {
        if (!res.ok) throw new Error('Error creating user')
        return res.json()
      })
      .then((data) => {
        console.log(data)
      })
      .catch((err) => console.error(err))
  }
  function login(email: string, password: string): Promise<string> {
    return fetch('http://localhost:6927/api/user/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ email, password }),
    })
      .then((res) => {
        if (!res.ok) throw new Error('Credenciales inválidas')
        return res.json()
      })
      .then((data) => {
        token.value = data.token
        if (!token.value) throw new Error('Token not received')
        localStorage.setItem('token', token.value)
        isLoggedIn.value = true
        return token.value
      })
      .catch((err) => {
        console.error('Error en el inicio de sesión:', err)
        throw err
      })
  }

  return { users, isLoggedIn, token, fetchAll, userById, register, login }
})
