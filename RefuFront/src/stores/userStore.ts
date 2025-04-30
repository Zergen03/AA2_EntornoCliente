import type { user } from '@/assets/core/user'
import { defineStore } from 'pinia'
import { computed, reactive } from 'vue'

export const useUserStore = defineStore('users', () => {
  const users = reactive(new Array<user>())

  function fetchAll(){
    if(users.length == 0){
        fetch('http://localhost:6927/api/User')
        .then((res) => res.json())
        .then(data => {
            const usersInfo: user[] = data.map((d: user) => ({
                id: d.id,
                Name: d.name,
                Email: d.email,
                IsVeteran: d.IsVeteran
            }))
            users.push(...usersInfo)
        })
    }
}

  function userById(id: number) {
    return users.find(user => user.id === id);
  }

  function addUser(){
    
  }

  return { users, fetchAll, userById }
})
