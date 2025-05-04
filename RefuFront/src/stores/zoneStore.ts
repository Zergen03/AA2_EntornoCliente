import { defineStore } from 'pinia'
import { reactive } from 'vue'

interface zone{
    id: number
    name: string
}

export const useZoneStore = defineStore('zones', () => {
  const zones = reactive(new Array<zone>())
  function fetchAll() {
    console.log("llamando a la api")
    fetch('http://localhost:6927/api/Zone')
      .then((res) => res.json())
      .then((data) => {
        const zoneInfo: zone[] = data.map((d: zone) => ({
          id: d.id,
          name: d.name
        }))
        zones.push(...zoneInfo)
        console.log(zones)
      })
  }

  return { zones: zones, fetchAll }
})
