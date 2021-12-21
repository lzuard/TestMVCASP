<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'
import dayjs from 'dayjs'

export default {
  name: 'UtilList',
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
        title: 'Список утилизаций',
        linkToCreate: '/utils/create',
        createCaption: 'Создать утилизацию',
        tableHeaders: [
          '№',
          'Сотрудник',
          'Номер ТТН',
          'Утилизатор',
          'Акт утилизации',
          'Дата отгрузки'
        ],
        tableData: [],
        sortTypes: []
      }
    }
  },
  created () {
    this.$api.util.getUtils()
      .then((data) => {
        this.handlingUtils(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке утилизаций')
      })
  },
  methods: {
    handlingUtils (data) {
      data.forEach((item) => {
        item.employee = `${item.employee.secondName} ${item.employee.firstName}`
        item.utilizer = item.utilizer.organizationName
        item.ttn = item.ttn.number
        item.shipmentDate = dayjs(item.shipmentDate).locale('ru-ru').format('DD/MM/YYYY')
      })
    }
  }
}
</script>
