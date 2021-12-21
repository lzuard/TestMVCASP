<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'
import dayjs from 'dayjs'

export default {
  name: 'ReturnList',
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
        title: 'Список возвратов',
        linkToCreate: '/returns/create',
        createCaption: 'Создать возврат',
        tableHeaders: [
          '№',
          'Номер заказа',
          'Номер ТТН',
          'Сотрудник',
          'Дата возврата',
          'Номер акта возврата',
          'Принято'
        ],
        tableData: [],
        sortTypes: []
      }
    }
  },
  created () {
    this.$api.returns.getReturns()
      .then((data) => {
        this.handlingSupplies(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке возвратов')
      })
  },
  methods: {
    handlingSupplies (data) {
      data.forEach((item) => {
        item.order = item.order.id
        item.employee = `${item.employee.secondName} ${item.employee.firstName}`
        item.ttn = item.ttn.number
        item.returnDate = dayjs(item.returnDate).locale('ru-ru').format('DD/MM/YYYY')
        item.isAccepted = item.isAccepted ? 'Да' : 'Нет'
      })
    }
  }
}
</script>
