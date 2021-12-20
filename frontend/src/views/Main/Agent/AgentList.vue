<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'

export default {
  name: 'AgentList',
  components: {
    Showcase
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список контрагентов',
        linkToCreate: '/agents/create',
        createCaption: 'Создать контрагента',
        tableHeaders: [
          '№',
          'Тип',
          'Адрес',
          'Наименование',
          'Расчетный счет',
          'ИНН',
          'Телефон',
          'Электронная почта'
        ],
        tableData: [],
        sortTypes: []
      }
    }
  },
  created () {
    this.$api.agent.getAgents()
      .then((data) => {
        this.handlingAgentData(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке контрагентов')
      })
  },
  methods: {
    handlingAgentData (data) {
      data.forEach((item) => {
        item.type = item.type.name
        item.address = `${item.address.index}, ${item.address.subject}, ${item.address.location}, ${item.address.street}, ${item.address.house}`
      })
    }
  }
}
</script>
